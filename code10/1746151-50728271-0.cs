    public static void getInput()
        {
            string input = Console.ReadLine();
            string mark = Player.player1 ? "X" : "O";
            for (int x = 0; x < theGrid.GetLength(0); x++)
            {
                for (int y = 0; y < theGrid.GetLength(1); y++)
                {
                    if (!input.Equals(theGrid[x, y])) continue;
                    theGrid[x, y] = mark;
                    // Assuming your done with this method, so just returning because we don't need to search the rest of the grid
                    return;
                }
            }
        }
