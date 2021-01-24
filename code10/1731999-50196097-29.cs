     var cell = Console.ReadLine();
     if (TryGetCoordinates(cell, out int indexRow, out int indexCol))
     {
         var target = board[indexRow, indexCol];
     }
     else
     {
         Console.WriteLine("The cell {0} does not exist.", cell);
     }
     // ...
     bool TryGetCoordinates(string cell, out int indexRow, out int indexCol)
     {
         // ...
     }
