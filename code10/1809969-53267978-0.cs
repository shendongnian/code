    string csvFile = @"c:\temp\test.csv
    string worksheetsName = "data";
    
    bool firstRowIsHeader = false;
    
    var format = new ExcelTextFormat();
    format.Delimiter = ',';
    format.TextQualifier = '"';
    
    using (MemoryStream ms = new MemoryStream())
    using (ExcelPackage package = new ExcelPackage(ms))
    {
         ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(worksheetsName);
         worksheet.Cells["A1"].LoadFromText(new FileInfo(csvFile), format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
    }
