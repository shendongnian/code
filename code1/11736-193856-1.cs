    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Reflection;
    using System.IO;
    using Excel;
    
    namespace testExcelconsoleApp
    {
        class Program
        {
            private String fileLoc = @"C:\temp\test.xls";
    
            static void Main(string[] args)
            {
                Program p = new Program();
                p.createExcel();
            }
    
            private void createExcel()
            {
                Excel.Application excelApp = null;
                Excel.Workbook workbook = null;
                Excel.Sheets sheets = null;
                Excel.Worksheet newSheet = null;
    
                try
                {
                    FileInfo file = new FileInfo(fileLoc);
                    if (file.Exists)
                    {
                        excelApp = new Excel.Application();
                        workbook = excelApp.Workbooks.Open(fileLoc, 0, false, 5, "", "",
                                                            false, XlPlatform.xlWindows, "",
                                                            true, false, 0, true, false, false);
    
                        sheets = workbook.Sheets;
    
                        //check columns exist
                        foreach (Excel.Worksheet sheet in sheets)
                        {
                            Console.WriteLine(sheet.Name);
                            sheet.Select(Type.Missing);
    
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(sheet);
                        }
    
                        newSheet = (Worksheet)sheets.Add(sheets[1], Type.Missing, Type.Missing, Type.Missing);
                        newSheet.Name = "My New Sheet";
                        newSheet.Cells[1, 1] = "BOO!";
    
                        workbook.Save();
                        workbook.Close(null, null, null);
                        excelApp.Quit();
                    }
                }
                finally
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(newSheet);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(sheets);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
    
                    newSheet = null;
                    sheets = null;
                    workbook = null;
                    excelApp = null;
    
                    GC.Collect();
                }
            }
        }
    }
