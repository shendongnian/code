    private void PopulateTable(XLWorkbook wb, string workSheetName, string tableName, IEnumerable list)
    {
        var ws = wb.Worksheet(workSheetName);
        var table = ws.Table(tableName);
        ws.Cell(2, 1).InsertData(list);
    }
