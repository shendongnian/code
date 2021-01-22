    m_columnTypeParserFactory = new ColumnTypeParserFactory();
    
    private void FillDataRow(List<ColumnTypeStrinRep> rowInput, DataRow row)
    {
        foreach (ColumnTypeStrinRep columnInput in rowInput)
        {
            var parser = m_columnTypeParserFactory.GetParser(columnInput.type);
            row[columnInput.columnName] parser.Parse(columnInput.stringRep);
        }
    }
