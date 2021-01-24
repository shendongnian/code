    public class SudokuSolver
    {
        //Initialisation code
        public SudokuSolver()
        {
            GridValue[,] SudokuGrid = new GridValue[9, 9];
        //###################
            for (int r=0; r < 9; r++) 
            { 
                for (int c = 0; c < 9; c++) 
                { 
                    SudokuGrid[r, c] = new GridValue(); 
                } 
            }
        //###################
            SudokuDisplay(SudokuGrid);
            Console.ReadKey();
        }
        //Store values for every slot
        class GridValue
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
        //Display the grid
        void SudokuDisplay(GridValue[,] Sudoku)
        {
            Sudoku[1, 1].Value = 1;
            Sudoku[1, 2].Value = 2;
            Console.WriteLine(Sudoku[0, 0].Value + Sudoku[1, 0].Value);
        }
        //To Do
        //Ask the values for every slot
        //Verify if the slot can contain a number
        //Choose the most appropriated number for the slot
        //End the program after user pressing an key
    }
