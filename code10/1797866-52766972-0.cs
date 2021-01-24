    using Excel = Microsoft.Office.Interop.Excel;
    
                var ExcelApp = new Excel.Application();
                Excel.Workbook workbook = ExcelApp.Workbooks.Open(path);
                ExcelApp.Visible = true;
                workbook.Save();
                workbook.Close();
                ExcelApp.Quit();
