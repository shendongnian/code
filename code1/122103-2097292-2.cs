    Excel.Application excel;
    Excel.Workbook workbook;
    Excel.Worksheet worksheet;
    Excel.Sheets sheets;
    Excel.Range range;
    
    excel = new Microsoft.Office.Interop.Excel.Application();
    workbook = excel.Workbooks.Open(workbookName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    sheets = workbook.Worksheets;
    ...
 
