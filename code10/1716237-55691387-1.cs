    internal List<Cell> GetColumnCells(Worksheet worksheet, string columnName)
    {
         var columnCells = worksheet.Descendants<Row>()
              .Where(r => r.Descendants<Cell>().FirstOrDefault(c => 
                  string.Compare(GetColumnName(c.CellReference.Value), columnName, true) == 0)
              )
              .OrderBy(r => GetRowIndex(r.CellReference))
              .ToList();
    }
  
