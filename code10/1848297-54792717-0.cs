    using System;
    using System.IO;
    
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            const string FileName = @"d:\test.xlsx";
            IWorkbook workbook = OpenWorkBook(FileName);
            ISheet sheet = workbook.GetSheet("Sheet3");
            HideRows(sheet);
            DeleteRows(sheet);
            SaveWorkBook(workbook, FileName);
    
            Console.WriteLine("Done. Press any key");
            Console.ReadKey();
        }
    
        private static IWorkbook OpenWorkBook(string workBookName)
        {
            using (FileStream file = new FileStream(workBookName, FileMode.Open, FileAccess.Read))
            {
                return new XSSFWorkbook(file);
            }
        }
    
        private static void HideRows(ISheet sheet)
        {
            
            for (int rowIndex = 0; rowIndex <= sheet.LastRowNum; rowIndex++)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row == null) continue; // Completely unused row returns null
                ICell cell = row.GetCell(3); // 0-based column index: 0=column A, 1=B, etc
                if (cell != null && cell.StringCellValue == "HideMe")
                {
                    row.Hidden = true;
                }
            }
        }
    
        private static void DeleteRows(ISheet sheet)
        {
            // When deleting we must iterate rows in reverse sequence
            for (int rowIndex = sheet.LastRowNum; rowIndex >= 0; rowIndex--)
            {
                IRow row = sheet.GetRow(rowIndex);
                if (row == null) continue;
                ICell cell = row.GetCell(3);
                if (cell != null && cell.StringCellValue == "DeleteMe")
                {
                    // use ShiftRows to actually delete the row:
                    sheet.ShiftRows(row.RowNum+1, sheet.LastRowNum, -1);
                }
            }
        }
    
        private static void SaveWorkBook(IWorkbook workbook, string workBookName)
        {
            string newFileName = Path.ChangeExtension(workBookName, "new.xlsx");
            using (FileStream file = new FileStream(newFileName, FileMode.Create, FileAccess.Write))
            {
                workbook.Write(file);
            }
    
            string backupFileName = Path.ChangeExtension(workBookName, "bak.xlsx");
            File.Replace(newFileName, workBookName, backupFileName);
        }
    }
