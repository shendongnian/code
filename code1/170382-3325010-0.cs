    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    
    namespace ExcelTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Excel.Application excelapplication = null;
                Excel.Workbook workbook = null;
                
                try
                {
                    excelapplication = new Excel.Application();
                    workbook = excelapplication.Workbooks.Open(args[0]);
                    var errors = new Dictionary<string, List<string>>();
                    foreach (Excel.Worksheet sheet in workbook.Sheets)
                    {
                        int rowCount = sheet.UsedRange.Cells.Rows.Count;
                        int colCount = sheet.UsedRange.Cells.Columns.Count;
                        var usedCells = sheet.UsedRange.Cells;
    
                        for (int i = 1; i <= rowCount; i++)
                        {
                            for (int j = 1; j <= colCount; j++)
                            {
                                Excel.Range range = usedCells[i, j];
                                List<string> cellErrors;
                                if (HasNonDefaultFont(range, out cellErrors))
                                {
                                    if (!IsHeaderCell(workbook, range))
                                    {
                                        string cellDisplayTitle = String.Format("{0}!{1}", sheet.Name, range.Address);
                                        errors[cellDisplayTitle] = cellErrors;
                                    }
                                }
                            }
                        }
                    }
                    ReportErrors(errors);
                }
                finally
                {
                    if (workbook != null)
                        workbook.Close();
                    if (excelapplication != null)
                        excelapplication.Quit();
                }
            }
    
            static bool HasNonDefaultFont(Excel.Range range, out List<string> differences)
            {
                differences = new List<string>();
    
                if (range.Font.Color != 0.0)
                    differences.Add("Has font-color");
    
                if (range.Font.Bold)
                    differences.Add("Is bold");
    
                if (range.Font.Italic)
                    differences.Add("Is italic");
    
                if (range.Font.Underline != (int)Microsoft.Office.Interop.Excel.XlUnderlineStyle.xlUnderlineStyleNone)
                    differences.Add("Is underline");
                
                if (range.Font.Strikethrough)
                    differences.Add("Is strikethrough");
    
                if (range.Font.Name != "Arial")
                    differences.Add(String.Format("Font is {0}", range.Font.Name));
    
                if (range.Font.Size != 10)
                    differences.Add(String.Format("Font size is {0}", range.Font.Size));
    
                return differences.Count != 0;
            }
    
            static bool IsHeaderCell(Excel.Workbook workbook, Excel.Range range)
            {
                // Look through workbook names:
                foreach (Excel.Name namedRange in workbook.Names)
                {
                    if (range.Parent == namedRange.RefersToRange.Parent && range.Application.Intersect(range, namedRange.RefersToRange) != null)
                        return true;
                }
    
                // Look through worksheet-names.
                foreach (Excel.Name namedRange in range.Worksheet.Names)
                {
                    if (range.Parent == namedRange.RefersToRange.Parent && range.Worksheet.Application.Intersect(range, namedRange.RefersToRange) != null)
                        return true;
                }
                return false;
            }
    
            static void ReportErrors(Dictionary<string, List<string>> errors)
            {
                if (errors.Count > 0)
                {
                    Console.WriteLine("Found the following errors:");
                    Console.WriteLine("---------------------------------");
                    Console.WriteLine("{0,-15} | Error", "Cell");
                    Console.WriteLine("---------------------------------");
                }
    
                foreach (KeyValuePair<string, List<string>> kv in errors)
                    Console.WriteLine("{0,-15} | {1}", kv.Key, kv.Value.Aggregate((e, s) => e + ", " + s));
            }
        }
    }
