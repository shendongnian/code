     var input = Console.ReadLine();
     if (TryGetCoordinates(input, out int irow, out int icol))
     {
         var target = board[irow, icol];
     }
     else
     {
         Console.WriteLine("The cell {0} does not exist.", input);
     }
     // ...
     bool TryGetCoordinates(string cell, out int indexRow, out int indexCol)
     {
         // ...
     }
