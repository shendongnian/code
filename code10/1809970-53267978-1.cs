    [HttpPost("upload")]
    public async Task<IActionResult> FileUpload(IFormFile file)
    {
        var result = string.Empty;
        string worksheetsName = "data";
    
        bool firstRowIsHeader = false;
        var format = new ExcelTextFormat();
        format.Delimiter = ',';
        format.TextQualifier = '"';
    
        using (var reader = new System.IO.StreamReader(file.OpenReadStream()))
        using (ExcelPackage package = new ExcelPackage())
        {
             result = reader.ReadToEnd();
             ExcelWorksheet worksheet = 
             package.Workbook.Worksheets.Add(worksheetsName);
             worksheet.Cells["A1"].LoadFromText(result, format, OfficeOpenXml.Table.TableStyles.Medium27, firstRowIsHeader);
        }     
    }
