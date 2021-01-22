    try
    {
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            string[] data = BreakLine(line);  
            DataRow dr = _DataTable.NewRow();
            // protect against overflow
            int maxColumns = Math.Min(_DataTable.Columns.Count, data.Length);
            for (int i = 0; i < maxColumns; i++)
            {
                dr[i] = data[i];
            }
            _DataTable.Rows.Add(dr);
        }
        return _DataTable;
    }
    finally
    {
        ...
