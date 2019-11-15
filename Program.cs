using System;

namespace RatMaze
{
    class Program
    {
        // Change the mazeSize and actual maze to create new maze
        const int mazeSize = 6;
        static int[,] maze = new int [mazeSize, mazeSize] {
            {1, 0, 1, 1, 1, 0},
            {1, 0, 1, 0, 1, 0},
            {1, 1, 1, 0, 1, 0},
            {1, 0, 1, 0, 1, 0},
            {1, 0, 1, 1, 1, 0},
            {1, 0, 1, 0, 1, 1}
        };

        // destination position
        static int destX = 5;
        static int destY = 5;

        static int[] PossibleMoveX = new int [4] { 1, -1, 0, 0};
        static int[] PossibleMoveY = new int [4] { 0, 0, 1, -1};

        static void Main(string[] args)
        {
            // starting posistion
            int x = 0;
            int y = 0;

            // initlize solution
            int [,] solution = new int[mazeSize,mazeSize];
            for (int i = 0; i < solution.GetLength(0); i++){
                for (int j = 0; j < solution.GetLength(1); j++){
                    solution[i, j] = 0;
                }
            }

            // print out the maze
            Console.WriteLine("Initial Maze:");
            PrintSolution(maze);

            // set starting position
            solution[x,y] = 1;

            if (RatMazeSolver(x, y, solution)){
                Console.WriteLine("Solution found:");
                PrintSolution(solution);
            }else{
                Console.WriteLine("Solution doesn't exist.");
            }
        }
        
        static void PrintSolution(int[,] solution){
            for (int i = 0; i < solution.GetLength(0); i++){
                for (int j = 0; j < solution.GetLength(1); j++){
                     Console.Write(solution[i,j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static bool ValidMove(int x, int y, int[,] solution)
        {
            return (x >= 0 && x < maze.GetLength(0) &&
                    y >= 0 && y < maze.GetLength(1) &&
                    maze[x,y] == 1 && solution[x,y] == 0);
        }

        static bool RatMazeSolver(int x, int y, int[,] solution){
            if (x == destX && y == destY) // base case: maze solved
            {
                return true;
            }

            int nextX, nextY;

            for (int i = 0; i < PossibleMoveX.Length; i++){
                nextX = x + PossibleMoveX[i];
                nextY = y + PossibleMoveY[i];
                if (ValidMove(nextX, nextY, solution)){                  
                    solution[nextX, nextY] = 1;
                    if (RatMazeSolver(nextX, nextY, solution))
                        return true;
                    solution[nextX, nextY] = 0;
                }
            }
            return false;
        }
    }
}
