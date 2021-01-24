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
         indexRow = (int)cell[0] - (int)'a';
         indexCol = (int)cell[1] - (int)'1';
         return indexRow < 5 && indexRow >= 0 && indexCol < 5 && indexCol >= 0;
     }
