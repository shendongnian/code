    using System;
    using System.IO;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    
    class Program
    {
        static void Main(string[] args)
        {
            var wb = new HSSFWorkbook();
            var sheet = wb.CreateSheet("Sheet1");
            sheet.FitToPage = false;
    
            const int limit = 30;
            var internalCounter = 0;
            var totalPageBreaks = 0;
            for (int j = 0; j < 100; j++)
            {
                IRow row = sheet.CreateRow(j + 2);
                if (internalCounter == limit)
                {
                    totalPageBreaks++;
                    sheet.SetRowBreak(j + 1);
                    internalCounter = 0;
                }
    
                ICell cellZero = row.CreateCell(0);
                ICell cellOne = row.CreateCell(1);
    
                cellZero.SetCellValue($"Counter {internalCounter + 1}");
                cellOne.SetCellValue($"BranchCode {j + 1}");
                internalCounter++;
            }
    
            var header = sheet.Header;
            header.Center = $"Page {HeaderFooter.Page} of {HeaderFooter.NumPages}";
    
            using (var file = new FileStream(@"C:\temp\Test1.xls", FileMode.Create))
            {
                wb.Write(file);
            }
    
            Console.WriteLine("Worksheet created. Press any key");
            Console.ReadLine();
        }
    }
