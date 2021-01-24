    using System;
    using OfficeOpenXml;
    using System.Collections.Generic;
    using System.IO;
    namespace eeplusPractice
    {
        class Program
        {
            static void Main(string[] args)
            {
                FileInfo newFile = new FileInfo(@"C:\Users\Evan\Desktop\new.xlsx");
                ExcelPackage pkg = new ExcelPackage(newFile);
                ExcelWorksheet wrksheet = pkg.Workbook.Worksheets[0];
    
                List<string> cabeceras = new List<string>();
    
                for (int x = 1; x < 5; x++)
                {
                    cabeceras.Add("HELLO");
                }
    
                int row = 4;
                
                for(int col = 1; col <= cabeceras.Count; col++)
                {
                    int counter = col;
                    wrksheet.Cells[row, col].Value = cabeceras[counter];
                }
    
                pkg.Save();
            }
        }
    }
