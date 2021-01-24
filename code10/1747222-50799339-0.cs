    // read the current row data
    XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);
    // LastCellNum is the number of cells of current rows
    int cellCount = headerRow.LastCellNum;
     // LastRowNum is the number of rows of current table
    int rowCount = sheet.LastRowNum + 1; 
     bool isBlanKRow = false;
    //Start reading data after first row(header row) of excel sheet.
    
    for (int i = (sheet.FirstRowNum + 1); i < rowCount; i++)
    {
        XSSFRow row = (XSSFRow)sheet.GetRow(i);
        DataRow dataRow = dt.NewRow();
        isBlanKRow = true;
        try
        {
            for (int j = row.FirstCellNum; j < cellCount; j++)
            {
                if (null != row.GetCell(j) && !string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                {
                    dataRow[j] = row.GetCell(j).ToString();
                    isBlanKRow = false;
                }
            }
        }
        catch (Exception Ex)
         { 
    
         }
         if (!isBlanKRow)
         {
             dt.Rows.Add(dataRow);
         }
         
    }
