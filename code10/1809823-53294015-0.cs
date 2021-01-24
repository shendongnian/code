    using Excel = Microsoft.Office.Interop.Excel;
    Excel.Application exc = new Excel.Application();
    exc.Interactive = true;
    var excelTemplate = "CompareResult.xlsx"; //Change it with your filename
    string FromPath = Path.GetFullPath(excelTemplate); //Get the full path of your excel 
    //file.
    Excel.Workbook wb = exc.Workbooks.Open(FromPath);
    Excel.Worksheet sh = wb.Sheets[1];
    int _lastRow = xlWorkSheet.Cells[xlWorkSheet.Rows.Count, 1].End[Excel.XlDirection.xlUp].Row + 1;
    sh.Cells[row, 1].Value2 = textBox1.Text;
    sh.Cells[row, 2].Value2 = textBox1.Text;
    sh.Cells[row, 3].Value2 = textBox1.Text;
    sh.Cells[row, 4].Value2 = textBox1.Text;
    wb.Save(); \\Saving the file when changing
    wb.Close(); 
    exc.Quit();
