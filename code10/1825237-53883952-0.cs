    using (var package = new ExcelPackage(new FileInfo(@"C: \Users\Emre Asus\Desktop\LongExcelDataRead-master\NoRatesFinalPL.xlsx")))
            {
               ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                for (int i = 1; i < workSheet.Dimension.End.Row ; i++)
                {
                    string value = workSheet.Cells[i, 2].Value.ToString();
                }
            } 
