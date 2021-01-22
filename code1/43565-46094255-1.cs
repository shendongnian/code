     Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
    
                    if (xlApp == null)
                    {
    
                        return;
                    }
    
    
                    xlApp.DisplayAlerts = false;
                    string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                            + "\\Sample.xlsx";
                    Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(filePath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                    Excel.Sheets worksheets = xlWorkBook.Worksheets;
                   
                    worksheets[4].Delete();
                    worksheets[3].Delete();
                    xlWorkBook.Save();
                    xlWorkBook.Close();
    
                    releaseObject(worksheets);
                    releaseObject(xlWorkBook);
                    releaseObject(xlApp);
