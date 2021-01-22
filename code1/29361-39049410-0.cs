        Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
        Microsoft.Office.Interop.Excel.Workbook wbv = excel.Workbooks.Open("C:\\YourExcelSheet.xlsx");
        Microsoft.Office.Interop.Excel.Worksheet wx = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
        
        wbv.Close(true, Type.Missing, Type.Missing);
        excel.Quit();
