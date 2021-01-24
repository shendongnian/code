    public class ExcelService: IExcelService {
        public Task<JArray> GetDataAsync(Stream stream) {
            JArray data = new JArray();
            using (ExcelPackage package = new ExcelPackage(stream)) {
                  ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 1; row <= rowCount; row++) {
                    for (int col = 1; col <= colCount; col++) {
                       //...populate data
                    }
                }
            }
            return data;
       }
    }
    
