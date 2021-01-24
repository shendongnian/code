    string[] expectedColumns = new string[] { "Column 1", "Column 2", "Column 3" };
    
    var workbook = ExcelFile.Load("Sample.xlsx");
    var worksheet = workbook.Worksheets[0];
    var firstRow = worksheet.Rows[0];
    
    string[] actualColumns = firstRow.AllocatedCells
        .Select(cell => cell.Value != null ? cell.Value.ToString() : string.Empty)
        .ToArray();
    
    for (int i = 0; i < expectedColumns.Length; i++)
        if (expectedColumns[i] != actualColumns[i])
            throw new Exception("Unexpected column name detected!");
