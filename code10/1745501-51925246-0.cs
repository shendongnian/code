    // use ExcelDataTableConfiguration.FilterRow to filter empty rows
    FilterRow = rowReader =>
    {
        var hasData = false;
        for (var i = 0; i < rowReader.FieldCount; i++)
        {
            if (rowReader[i] == null || string.IsNullOrEmpty(rowReader[i].ToString()))
            {
                continue;
            }
            hasData = true;
            break;
        }
        return hasData;
    },
    // use ExcelDataTableConfiguration.FilterColumn to filter empty columns
    FilterColumn = (rowReader, colIndex) =>
    {
        var hasData = false;
        rowReader.Reset();
        // this will skip first row as it is name of column
        rowReader.Read();
        while (rowReader.Read())
        {
            if (rowReader[colIndex] == null || 
                string.IsNullOrEmpty(rowReader[colIndex].ToString()))
            {
                continue;
            }
            hasData = true;
            break;
        }
        // below codes do a trick!
        rowReader.Reset();
        rowReader.Read();
        return hasData;
    }
