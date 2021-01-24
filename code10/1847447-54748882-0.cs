    class Program
    {
            static void Main(string[] args)
    	{
    		string csvDocument = @"FL_insurance_sample.csv";
    		var lines = ReadCsv(csvDocument, delimiter: ',');
    		ConvertWithNPOI("NPOI.xlsx", "NPOI", lines);
    	}
    
            private static bool ConvertWithNPOI(string excelFileName, string worksheetName, IEnumerable<string[]> csvLines)
            {
                if (csvLines == null || csvLines.Count() == 0)
                {
                    return (false);
                }
    
                int rowCount = 0;
                int colCount = 0;
    
                IWorkbook workbook = new XSSFWorkbook();
                ISheet worksheet = workbook.CreateSheet(worksheetName);
    
                foreach (var line in csvLines)
                {
                    IRow row = worksheet.CreateRow(rowCount);
    
                    colCount = 0;
                    foreach (var col in line)
                    {
                        row.CreateCell(colCount).SetCellValue(TypeConverter.TryConvert(col));
                        colCount++;
                    }
                    rowCount++;
                }
    
                using (FileStream fileWriter = File.Create(excelFileName))
                {
                    workbook.Write(fileWriter);
                    fileWriter.Close();
                }
    
                worksheet = null;
                workbook = null;
    
                return true;
    	}
    
    	private static bool ConvertWithEPPlus(string csvFileName, string excelFileName, string worksheetName, char delimiter = ';')
    	{
                bool firstRowIsHeader = false;
    
                var format = new ExcelTextFormat();
                format.Delimiter = delimiter;
                format.EOL = "\r";              // DEFAULT IS "\r\n";
                // format.TextQualifier = '"';
    
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFileName)))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetName);
                    worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFileName), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
                    package.Save();
                }
    
                return (true);
    	}
    }
