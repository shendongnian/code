    using Microsoft.Office.Interop.Excel;
    // Connect to Excel
    Microsoft.Office.Interop.Excel.ApplicationClass excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
    // Do this if you want to see Excel 
    excelApp.Visible = true;
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
        worksheet.Activate(); // do this if you have Excel visible so you can see what you're doing
    }
    // Close the workbook
    excelApp.Workbooks.Close();
    // Close Excel
    excelApp.Application.Quit();
