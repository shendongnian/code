    public async Task<DataTable> GetDataTableFromTabRowColumn(string sheetName, int startRow, int endRow, int startCol, int endCol)
    {                  
        var task = Task.Run(() =>
        {            
            Workbook wb = new Workbook(FilePath); // error line
            Worksheet worksheet = wb.Worksheets[sheetName];
            DataTable dt = worksheet.Cells.ExportDataTable(startRow - 1, startCol - 1, (endRow - startRow + 1), (endCol - startCol + 1), options);
            return dt;
        });
        return await task;            
    }
