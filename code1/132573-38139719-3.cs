    using Excel = Microsoft.Office.Interop.Excel;
    string xlBk = @"D:\Test.xlsx";
    Excel.Application xlApp;
    Excel.Workbook xlWb;
    Excel.Worksheet xlWs;
    Excel.Range rng;
    int iLast;
    xlApp = new Excel.Application();
    xlWb = xlApp.Workbooks.Open(xlBk, 0, true, 5, "", "", true, 
    Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
    xlWs = (Excel.Worksheet)xlWb.Worksheets.get_Item(1);
    iLast = xlWs.Rows.Count;
    rng = (Excel.Range)xlWs.Cells[iLast, 1];
    iLast = rng.get_End(Excel.XlDirection.xlUp).Row;
