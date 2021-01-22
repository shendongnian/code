    static List<string> GetDataReaderColumnNames(IDataReader rdr)
    {
        var columnNames = new List<string>();
        for (int i = 0; i < rdr.FieldCount; i++)
            columnNames.Add(rdr.GetName(i));
        return columnNames;
    }
