     XSSFRow row = (XSSFRow)sheet.GetRow(i);
         for (int j = row.FirstCellNum; j < cellCount; j++)
         {
                if (null != row.GetCell(j) && !string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                 {
                    Console.Write(row.GetCell(j).ToString());
                 }
         }
