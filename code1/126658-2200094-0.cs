    Microsoft.Office.Interop.Excel.Application _excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Workbook workBook = _excelApp.Workbooks.Open(@"d:\test.xls",
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing);
                    
                    workBook.SaveAs(@"d:\test.xml", 
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlXMLSpreadsheet, 
                        null, 
                        null,
                        true,
                        true,
                        XlSaveAsAccessMode.xlNoChange,
