    public class ExcelExtractor<T> where T: class, new()
    {
        public ExcelExtractor(IExcelPathProvider pathProvider) => _pathProvider = pathProvider;
        public List<T> Create(int sheetNumber)
        {
            using (var excelPackage = new ExcelPackage(new FileInfo(_pathProvider.GetPath())))
            {
                var worksheet = excelPackage.Workbook.Worksheets[sheetNumber];
                return worksheet
                    .Extract<T>()
                    .WithAllProperties()
                    .GetData(2, row => worksheet.Cells[row, 1].Value != null)
                    .ToList();
            }
        }
        private readonly IExcelPathProvider _pathProvider;
    }
