     bool TryGetCoordinates(string cell, out int indexRow, out int indexCol)
     {
		 indexRow = -1;
		 indexCol = -1;
         if (cell == null)
         {
             return false;
         }
         if (cell.Length != 2)
         {
             return false;
         }
         // ...
     }
