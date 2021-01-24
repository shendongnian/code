    public class ExcelService: IExcelService {
        public async Task<JArray> GetDataAsync(Stream stream) {
            JArray data = new JArray();
            using (ExcelPackage package = new ExcelPackage(stream)) {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                if (worksheet.Dimension != null) {
                    data = await Task.Run(() => createJson(worksheet));
                }
            }
            return data;
        }
       
        private JArray createJson(ExcelWorksheet worksheet) {
            JArray data = new JArray();
            int colCount = worksheet.Dimension.End.Column;  //get Column Count
            int rowCount = worksheet.Dimension.End.Row;     //get row count
            for (int row = 1; row <= rowCount; row++) {
                JObject jobject = new JObject();
                for (int col = 1; col <= colCount; col++) {
                    var value = worksheet.Cells[row, col].Value;
                    //Excel has 2 columns and I want to create a json from that.
                    if (col == 1) {
                        jObject.Add("ID", rowValue.ToString());
                    } else {
                        jObject.Add("Name", rowValue.ToString());
                    }
                    data.Add(jObject);
                }
            }
            return data;
        }
    }
    
