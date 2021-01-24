    using System;
    
    namespace ConsoleApp1
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
    
                SudokuSolver sudokuSolver = new SudokuSolver(9, 9);
    
                sudokuSolver.DisplayGrid();
    
                Console.ReadKey();
            }
        } 
    
    
        public class SudokuSolver
        {
            //Store every values needed for every "slot"
            public class GridValue
            {
                public bool CanBe1 { get; set; } = false;
                public bool CanBe2 { get; set; } = false;
                public bool CanBe3 { get; set; } = false;
                public bool CanBe4 { get; set; } = false;
                public bool CanBe5 { get; set; } = false;
                public bool CanBe6 { get; set; } = false;
                public bool CanBe7 { get; set; } = false;
                public bool CanBe8 { get; set; } = false;
                public bool CanBe9 { get; set; } = false;
                public bool AlreadySolved { get; set; } = false;
                public int Value { get; set; } = 0;
            }
            public GridValue[,] SudokuGrid { get; }
    
            //Code d'initialisation
            public SudokuSolver(int x, int y)
            { 
                // only initialize in the constructor, no calls
                SudokuGrid = new GridValue[x, y]; // the array exists now in mem, but each entry is pointing to null
                for (int i = 0; i < x; i++)
                {
                    for (int j = 0; j < y; j++)
                    {
                        SudokuGrid[i, j] = new GridValue();
                    }
                }
            }
   
   
            //Display the grid => then name it that way!
            public void DisplayGrid()
            {
                SudokuGrid[1, 1].Value = 1;
                SudokuGrid[1, 2].Value = 2;
                Console.WriteLine(SudokuGrid[0, 0].Value + SudokuGrid[1, 0].Value);
            }
    
    
         }
    
    }
