    public void PrintBoard(Board b)
    {
       for (int col = 0; col < board.Width; col ++)
       {
          for (int row = 0, row < board.Height; row++)
          {
             Counter c = board.GetCounter[row][col];
             Console.Write(c == null ? " " : "*");
          }
          Console.WriteLine();
       }
    }
