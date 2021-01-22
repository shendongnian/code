    Microsoft.Office.Interop.Excel.Application excel;
    Microsoft.Office.Interop.Excel.Workbook workbook;
    Microsoft.Office.Interop.Excel.Worksheet worksheet;
    Microsoft.Office.Interop.Excel.Sheets sheets;
    Microsoft.Office.Interop.Excel.Range range;
    
    excel = new Microsoft.Office.Interop.Excel.Application();
    workbook = excel.Workbooks.Open(workbookName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    sheets = workbook.Worksheets;
    ...
 
