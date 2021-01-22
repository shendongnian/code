    using System;
    using SpreadsheetGear;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Load Book.xlsx.
                IWorkbook workbook = Factory.GetWorkbook(@"c:\Book.xlsx");
                // Write the address and formatted text value of each
                // cell to the console.
                foreach (IRange cell in workbook.Worksheets[0].UsedRange)
                    Console.WriteLine("{0}='{1}'", cell.Address, cell.Text);
            }
        }
    }
