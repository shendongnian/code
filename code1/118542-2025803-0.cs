    using Microsoft.Office.Interop.Excel;
    Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open("MyFile.xls"
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    Microsoft.Office.Interop.Excel.Sheets sheets = workbook.Worksheets;
    for (sheet = 1; sheet <= sheets.Count; sheet++)
    {
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(sheet);
        // Do something with the worksheet
    }
