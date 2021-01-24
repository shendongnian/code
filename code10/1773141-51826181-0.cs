       var row = sheet.CreateRow(0);
       row.CreateCell(j).SetCellValue(table.Tables[0].Rows[i][j].ToString());
        
        // or 
        row.Cells[j].SetCellValue(table.Tables[0].Rows[i][j].ToString());
        
        
        // Or 
        
        
        ISheet sheet1 = hssfworkbook.GetSheet("Табель");
        for (int i = 0; i < table.Tables[0].Rows.Count; i++)
        {  
          		HSSFRow row = (HSSFRow)sheet1.GetRow(i+5);
           
            for (int j = 0; j < table.Tables[0].Columns.Count; j++)
            {
        if (table.Tables[0].Rows[i][j].ToString() != "0")
            row.GetCell(j).SetCellValue(table.Tables[0].Rows[i][j].ToString());
        else
            row.GetCell(j).SetCellValue("");
            }
        }
