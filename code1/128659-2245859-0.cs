    using System;
    using SpreadsheetGear;
    namespace FormatConditions
    {
        class Program
        {
            static void Main(string[] args)
            {
                // Create a new empty workbook.
                IWorkbook workbook = Factory.GetWorkbook();
                IRange cells = workbook.Worksheets[0].Cells["A1:A5"];
                // Place formulas resulting in random numbers between 0 and 1000.
                cells.Formula = "=RAND()*1000";
                cells.NumberFormat = "0";
                // Add a format condition to use blue background and white text for numbers >500.
                IFormatCondition fc = cells.FormatConditions.Add(FormatConditionType.CellValue, FormatConditionOperator.Greater, "500", "");
                fc.Interior.Color = System.Drawing.Color.Navy;
                fc.Font.Color = System.Drawing.Color.White;
                // Save to xls and xlsx.
                workbook.SaveAs(@"c:\tmp\FormatConditions.xls", FileFormat.Excel8);
                workbook.SaveAs(@"c:\tmp\FormatConditions.xlsx", FileFormat.OpenXMLWorkbook);
            }
        }
    }
