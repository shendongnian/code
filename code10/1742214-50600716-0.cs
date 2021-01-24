    string l_connectionString = "";
    string l_filePath = txtComparisonFile.Text;     
                                     
    string l_fileExt = System.IO.Path.GetExtension(l_filePath);
    if(l_fileExt.CompareTo(".xls") == 0)
          l_connectionString = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + l_filePath + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; 
    else
          l_connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + l_filePath + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1';";
                        Excel.Application excelApp = new Excel.Application();
                        excelApp.Visible = false;
                        string workbookPath = l_filePath;
                        Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(workbookPath,
                                0, false, 5, "", "", false, Excel.XlPlatform.xlWindows, "",
                                true, false, 0, true, false, false);
                        Excel.Sheets excelSheets = excelWorkbook.Worksheets;
                        string currentSheet = l_selectedSheet;
                        Excel.Worksheet excelWorksheet = (Excel.Worksheet)excelSheets.get_Item(currentSheet);
                        Excel.Range excelCell = (Excel.Range)excelWorksheet.get_Range(l_comparisonSheetRange);
                        excelWorksheet.Columns.NumberFormat = "@";
                        excelWorkbook.Save();
                        excelWorkbook.Close();
                        g_objExcelHelper.g_objDtCompare = g_objExcelHelper.GetDataTable(l_connectionString, l_selectedSheet, l_comparisonSheetRange, g_objExcelHelper.g_objDtCompare);
}
