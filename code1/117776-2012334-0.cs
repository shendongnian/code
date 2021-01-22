    //using Excel = Microsoft.Office.Interop.Excel;
    Excel.ApplicationClass app = new Excel.ApplicationClass();
    Excel.Workbook workbook = app.Workbooks.Open("YourFile.xls", 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets["Number 3"];
    worksheet.Activate();
