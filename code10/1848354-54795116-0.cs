    using System;
    using Excel = Microsoft.Office.Interop.Excel;
    using System.IO;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApp3
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Which solution to use?\n1  - for running Excel or \n2 - for using OpenXML");
                var result = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(result)) return;
    
                String tp_folder = @"c:\tp\";
                String[] tps = Directory.GetFiles(tp_folder);
    
                if (result == "1")
                {
                    DeleteNamesWithExcelApp(tps);
                }
                else if (result == "2")
                {
                    var cls = new OpenXmlSolution();
                    foreach (String m in tps)
                    {
                        cls.RemoveNames(m);
                    }
                }
    
                Console.WriteLine("Done");
                Console.ReadLine();
            }
    
            public static void DeleteNamesWithExcelApp(String[] tps)
            {
    
                Excel.Workbooks xlWorkbooks = null;
                Excel.Workbook xlWorkbook = null;
                Excel.Names ranges = null;
    
                var xlApp = new Excel.Application();
                try
                {
                    foreach (String m in tps)
                    {
                        xlWorkbooks = xlApp.Workbooks;
                        xlWorkbook = xlWorkbooks.Open(m);
                        ranges = xlWorkbook.Names;
                        int leftoveritems = ranges.Count;
                        
                        Excel.Name name = null;
                        try
                        {
                            for (int i = leftoveritems; i >= 1; i--)
                            {
                                name = xlWorkbook.Names.Item(i);
                                name.Delete();
                                if (name != null) Marshal.ReleaseComObject(name);
                                name = null;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        finally
                        {
                            if (name != null) Marshal.ReleaseComObject(name);
                        }
                        if (xlWorkbook != null)
                        {
                            xlWorkbook.Close(true);
                            Marshal.ReleaseComObject(xlWorkbook);
                            xlWorkbook = null;
                        }
                        if (xlWorkbooks != null) Marshal.ReleaseComObject(xlWorkbooks);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    if (ranges != null) Marshal.ReleaseComObject(ranges);
                    if (xlWorkbook != null) Marshal.ReleaseComObject(xlWorkbook);
                    if (xlWorkbooks != null) Marshal.ReleaseComObject(xlWorkbooks);
                    if (xlApp != null)
                    {
                        xlApp.Quit();
                        Marshal.ReleaseComObject(xlApp);
                        xlApp = null;
                    }
                }
            }
        }
    }
