     bool TryGetCoordinates(string cell, out int indexRow, out int indexCol)
     {
         if (cell == null)
         {
             return false;
         }
         if (cell.Length != 2)
         {
             return false;
         }
         indexRow = (int)cell[0] - (int)'a';
         indexCol = (int)cell[1] - (int)'1';
         return indexRow < 5 && indexRow >= 0 && indexCol < 5 && indexCol >= 0;
     }
