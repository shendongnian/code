    public static TimeSpan ExtractTimeData(this DataRow obj, string column)
    {
        // check column exists in dataTable
        var exists = obj.Table.Columns.Contains(column);
        if (exists)
        {
            // ensure we're not trying to parse null value
            if (obj[column] != DBNull.Value)
            {
                TimeSpan time;
                
                if (TimeSpan.TryParse(obj[column].ToString(), out time))
                {
                    // return if we can parse to TimeSpan
                    return time;
                }
            }
        }
        
        // return default TimeSpan if there is an error
        return default(TimeSpan);
    }
