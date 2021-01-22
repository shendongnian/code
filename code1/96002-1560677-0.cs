    using System;
    using System.Diagnostics;
    using SpreadsheetGear;
    using SpreadsheetGear.Advanced.Cells;
    namespace WriteRows
    {
        class Program
        {
            static void Main(string[] args)
            {
                // "Warm up" the code.
                WriteRows(100, 10, false);
                // Do the test.
                WriteRows(8000, 10, false);
            }
            static void WriteRows(int rows, int cols, bool openXML)
            {
                Stopwatch timer = Stopwatch.StartNew();
                IWorkbook workbook = Factory.GetWorkbook();
                IWorksheet worksheet = workbook.Worksheets[0];
                IValues values = (IValues)worksheet;
                for (int row = 0; row < rows; row++)
                {
                    values.SetText(row, 0, "Row " + (row + 1));
                    for (int col = 1; col < cols; col++)
                        values.SetNumber(row, col, row * cols + col);
                }
                string filename = @"c:\tmp\WriteRows" + (openXML ? ".xlsx" : ".xls");
                FileFormat fileFormat = openXML ? FileFormat.OpenXMLWorkbook : FileFormat.Excel8;
                workbook.SaveAs(filename, fileFormat);
                Console.WriteLine("Created {0} with {1}x{2} rows / cols in {3} seconds", filename, rows, cols, timer.Elapsed.TotalSeconds);
            }
        }
    }
