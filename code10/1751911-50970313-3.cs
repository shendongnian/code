    // Start writing the CSV file
    using (TextWriter _w   = new StreamWriter(String.Format("{0}\\{1}[{2}].csv", args[2], args[1], GetDateTime())))
    using (CsvWriter  _csv = new CsvWriter(_w)) {
        _csv.Configuration.Delimiter = ",";
        // Writes the column names
        for (int i = 0; i < ODBCSQL.ColumnsCount; i++)
            _csv.WriteField(ODBCSQL.GetColumnName(i));
        _csv.NextRecord();
        // Starts writing the rows
        List<string> _elements = ODBCSQL.GetAllElements();
        for (int i = 0; i < (ODBCSQL.ElementsCount * ODBCSQL.ColumnsCount); i += ODBCSQL.ColumnsCount) {
            for (int j = 0; j < ODBCSQL.ColumnsCount; j++) {
                _csv.WriteField(_elements[i + j], true);
                if (j == ODBCSQL.ColumnsCount - 1)
                    _csv.NextRecord();
            }
        }
        _w.Flush();
    }
