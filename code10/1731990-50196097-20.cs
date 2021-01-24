     private static bool TryGetCoordinates(string cell, out int indexRow, out int indexCol)
     {
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
