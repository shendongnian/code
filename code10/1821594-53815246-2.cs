    public static TimeSpan ExtractTimeData(this DataRow row, string column)
    {
        // check column exists in dataTable
        var exists = row.Table.Columns.Contains(column);
        if (exists)
        {
            // ensure we're not trying to parse null value
            if (row[column] != DBNull.Value)
            {
                TimeSpan time;
                
                if (TimeSpan.TryParse(row[column].ToString(), out time))
                {
                    // return if we can parse to TimeSpan
                    return time;
                }
            }
        }
        
        // return default TimeSpan if there is an error
        return default(TimeSpan);
    }
