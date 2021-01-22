    Excel.Application excelApp = new Excel.Application();
    excelApp.Visible = true;
    Excel.Workbook workbook = excelApp.Workbooks.Open("C:\MyWorkbook.xls",
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    // They key line:
    Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets["SubSignOff"];
