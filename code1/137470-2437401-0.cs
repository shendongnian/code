    using System;
    using SpreadsheetGear;
    namespace Program
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Load a workbook from disk and get the first worksheet.
                var workbook = SpreadsheetGear.Factory.GetWorkbook(@"C:\tmp\Numbers.xlsx");
                // Allocate a list of doubles to store the number.
                var numbers = new System.Collections.Generic.List<double>();
                var worksheet = workbook.Worksheets[0];
                // Assuming that column A is the column with the numbers...
                var columnA = worksheet.Cells["A:A"];
                var usedRange = worksheet.UsedRange;
                // Limit the cells we look at to the used range of the sheet.
                var numberCells = usedRange.Intersect(columnA);
                // Get the numbers into the list.
                foreach (IRange cell in numberCells)
                {
                    object val = cell.Value;
                    if (val is double)
                        numbers.Add((double)val);
                }
                // Write the numbers to the console.
                foreach (double number in numbers)
                    Console.WriteLine("number={0}", number);
            }
        }
    }
