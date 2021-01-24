    // Get the cells in the specified column and order them by row.
    internal List<Cell> GetColumnCells(Worksheet worksheet, string columnName)
    {
        var columnCells = worksheet.Descendants<Cell>()
            .Where(c => string.Compare(GetColumnName(c.CellReference.Value), columnName, true) == 0)
            .OrderBy(r => GetRowIndex(r.CellReference))
            .ToList();
    }                            
    private string GetColumnName(StringValue cellName)
    {
        var regex = new Regex("[a-zA-Z]+");
        var match = regex.Match(cellName);
        return match.Value;
    }
    private uint GetRowIndex(StringValue cellName)
    {
        var regex = new Regex(@"\d+");
        var match = regex.Match(cellName);
        return uint.Parse(match.Value);
    }
