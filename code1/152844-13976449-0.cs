    string fileName = @"c:\Book1.xlsx";
    Application app = new Application();
    Workbook wb = app.Workbooks.Open(fileName,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing, Type.Missing, Type.Missing,
       Type.Missing, Type.Missing);
    Worksheet sheet = wb.Sheets[1];  //Change to the sheet you care about (1 based index)
    var cell = sheet.Cells[1, 1];    //Change to the cell you care about (1 based index)
    string cellNumberFormat = cell.NumberFormat; //Number format of cell to compare against known values
