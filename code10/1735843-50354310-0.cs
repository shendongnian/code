     using OfficeOpenXml;
     using System.Collections.Generic;
     using System.IO;
    namespace equals
    {
        class Program
        {
             public static void Main()
            {
                try
                {
                    FileInfo newfile = new FileInfo(@"Z:\New folder\Test123.xlsx");
                    ExcelPackage pkg = new ExcelPackage(newfile);
                    ExcelWorksheet wrksheet = pkg.Workbook.Worksheets[0];
                    ExcelRange rng = wrksheet.Cells[1,1,2,2];
                    System.Console.WriteLine(rng.Address);
                    List<int> valuesInRange = new List<int>();
                    int cellValue;
                    foreach (var cell in rng)
                    {
                        cellValue = System.Convert.ToInt32(cell.Value);
                        if (cellValue != 0)
                        {
                             valuesInRange.Add(cellValue);
                        }
                    }
                    foreach (var item in valuesInRange)
                    {
                        System.Console.WriteLine(item);
                    }
                }
                catch (System.IO.IOException err)
                {
                    System.Console.WriteLine(err.Message);
                }
            }
        }
    }
