    using Excel = Microsoft.Office.Interop.Excel;
    
    Excel.Application app = new Excel.Application();
    //Open existing workbook
    //Excel.Workbook workbook = xlApp.Workbooks.Open(fileName);
    //Create new workbook
    Excel.Workbook workbook = app.Workbooks.Add();
    
    Excel.Worksheet worksheet = workbook.ActiveSheet;
    
    worksheet.Cells[1,1] = "Hello world!"; // Indexes start at 1, because Excel
    workbook.SaveAs("C:\\MyWorkbook.xlsx");
    workbook.Close();
    app.Quit();
