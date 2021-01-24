    public static void getInput()
        {
            string input = Console.ReadLine();
    
            if (Player.player1)
            {
                    for (var row = 0; row < theGrid.GetLength(0); row++)
                    {
                        for (var column = 0; column < theGrid.GetLength(1); column++)
                        {
                            if (input == theGrid[row, column])
                            {
                                theGrid[row, column] = "X";
                                break;
                            }
                        }
                    }
           ...
