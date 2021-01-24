    //Create workbook
    Workbook wb = new Workbook();
    //Access first worksheet
    Worksheet ws = wb.Worksheets[0];
    //Set some data in column index 3 which is greater in length than column width.
    ws.Cells["D4"].PutValue("This is simple text. This is another.");
    //This is your code
    int col = 3;
    AutoFitterOptions afo = new AutoFitterOptions();
    afo.AutoFitMergedCells = true;
    afo.OnlyAuto = false;
    ws.AutoFitColumns(col, col, afo);
    //Save the output Excel file
    wb.Save("output.xlsx");
