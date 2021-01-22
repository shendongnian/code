    using Microsoft.Office.Interop.Excel;
    using System.Reflection;
    
    namespace ExcelAutomationConsole
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                _Application excelApp = null;
                try
                {
                    excelApp = new ApplicationClass();
                    excelApp.Visible = true;
    
                    Missing missing = Missing.Value;
                    excelApp.Workbooks.Add(missing);
                    // or
                    //excelApp.Workbooks.Open("file.xlsx", missing, missing, missing, missing,
                    //                        missing, missing, missing, missing,
                    //                        missing, missing, missing, missing,
                    //                        missing, missing);
    
                    Worksheet sheet = excelApp.ActiveWorkbook.ActiveSheet as Worksheet;
                    Range r = sheet.Cells[1, 1] as Range;
                    r.FormulaR1C1 = "Test";
                }
                finally
                {
                    excelApp.Quit();
                }
            }
        }
    }
        
