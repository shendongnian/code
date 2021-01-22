         int startRow = 1;
         bool hasContent = false;
         int row = startRow;
         do
         {
            var cell = (Excel.Range)sheet.Cells[row,1];
            if (cell.Value2 != null)
            {
               hasContent = true;
               row++;
            }
         }
         while (hasContent);
