    public class ExcelUpdater
    {
        public void UpdateExcel(string pathToFile)
        {
            using (var package = new ExcelPackage(new FileInfo(pathToFile)))
            {
                var worksheet = package.Workbook.Worksheets.First();
                var lastRow = worksheet.Dimension.End.Row;
                for (var row = 1; row <= lastRow; row++)
                {
                    worksheet.Cells[row, 1].Value = ReverseText(worksheet.Cells[row, 1].Text);
                }
                package.Save();
            }
        }
        private string ReverseText(string value)
        {
            return new string(value.Reverse().ToArray());
        }
    }
