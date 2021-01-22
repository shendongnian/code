    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application AppName = new Excel.Application();
    Excel.Workbook bookName = AppName.Workbooks.Open(C:\....\test1);
    Excel.Worksheet sheetName = AppName.Worksheets.get_Item(1);
    sheetName.Rows[5].Cells[5].Value = "hello!";  //that writes hello in cell 5,5 in test1.xls
    string box;
    box = sheetName.Rows[10].Cells[10].Value;  //that reads the value of 10,10 cell in test1.xls and place it in box variable
