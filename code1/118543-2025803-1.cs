    using Microsoft.Office.Interop.Excel;
    // Conenct to Excel
    Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
    // Open the spreadsheet
    Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open("MyFile.xls"
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    // Get the collection of worksheets
    Microsoft.Office.Interop.Excel.Sheets sheets = workbook.Worksheets;
    for (sheet = 1; sheet <= sheets.Count; sheet++)
    {
        Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(sheet);
        // Do something with the worksheet
    }
    // Close the workbook
    excelApp.Workbooks.Close();
    // Close Excel
    excelApp.Application.Quit();
