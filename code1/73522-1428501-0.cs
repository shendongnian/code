            object opt = System.Reflection.Missing.Value;
            Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Open(WorkBookToOpen,
                                                     opt, opt, opt, opt, opt, opt, opt,
                                                     opt, opt, opt, opt, opt, opt, opt);
            Excel.Worksheet worksheet = workbook.Worksheets[1] as Microsoft.Office.Interop.Excel.Worksheet;
            string firstSheetName = worksheet.Name;
