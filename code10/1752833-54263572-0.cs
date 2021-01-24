    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
    {
        List<string> skipColumns = new List<string> { "SLNO", "FY" };
        using (var reader = ExcelReaderFactory.CreateReader(stream))
        {
            var result = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true,
                    FilterColumn = (rowReader, columnIndex) =>
                    {
                        return !skipColumns.Contains((rowReader[columnIndex].ToString()));
                    }
                }
            });
        }
    }
