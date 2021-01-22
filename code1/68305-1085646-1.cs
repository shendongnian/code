    Microsoft.Office.Interop.Excel.Workbook SelWorkBook = excelappln1.Workbooks.Open(
    	curfile,
        0, false, 5, "", "", false,
        Microsoft.Office.Interop.Excel.XlPlatform.xlWindows,
        "", true,
        false, 0, false, false, false);
        
    Microsoft.Office.Interop.Excel.Sheets excelSheets = SelWorkBook.Worksheets;
    Microsoft.Office.Interop.Excel.Worksheet excelworksheet =(Microsoft.Office.Interop.Excel.Worksheet)excelSheets.get_Item(CurSheetName);
    
    Microsoft.Office.Interop.Excel.Range excelRange = excelworksheet.UsedRange;
    
    if ((!excelworksheet.Cells[CurTaskNode.DATA_MIN_ROW + minRow, CurTaskNode.DATA_MIN_COL + minCol]).Locked)
    {
    	// Assigning the Value from reader to the particular cell in excel sheet 
    	excelworksheet.Cells[CurTaskNode.DATA_MIN_ROW + minRow, CurTaskNode.DATA_MIN_COL +      minCol] = values[iValueIndex];
    	iValueIndex++;
    }
