    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SpreadsheetGear;
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // Run once with 100 rows and then run forever with 1,000,000 rows.
                    for (int rows = 100; rows <= 1000000; rows = 1000000)
                    {
                        Console.Write("rows={0}, ", rows);
                        var startMemory = System.GC.GetTotalMemory(true);
                        var timer = System.Diagnostics.Stopwatch.StartNew();
                        var workbook = BuildWorkbook(rows);
                        var usedMemory = System.GC.GetTotalMemory(true) - startMemory;
                        Console.WriteLine("usedMemory={0}, time={1} seconds, workbook.Name={2}", usedMemory, timer.Elapsed.TotalSeconds, workbook.Name);
                        workbook = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("got exception={0}", e.Message);
                }
            }
            static IWorkbook BuildWorkbook(int rows)
            {
                var workbook = Factory.GetWorkbook();
                var worksheet = workbook.Worksheets[0];
                var values = (SpreadsheetGear.Advanced.Cells.IValues)worksheet;
                Random rand = new Random();
                int cols = 40;
                for (int col = 0; col < cols; col++)
                {
                    for (int row = 0; row <= rows; row++)
                    {
                        values.SetNumber(row, col, rand.NextDouble());
                    }
                }
                workbook.SaveAs(string.Format(@"c:\tmp\Rows{0}.xlsx", rows), FileFormat.OpenXMLWorkbook);
                return workbook;
            }
        }
    }
