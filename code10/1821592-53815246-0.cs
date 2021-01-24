    public static TimeSpan ExtractTimeData(this DataRow obj, string column)
    {
        var exists = obj.Table.Columns.Contains(column);
        if (exists)
        {
            if (obj[column] != DBNull.Value)
            {
                TimeSpan time;
                if (TimeSpan.TryParse(obj[column].ToString(), out time))
                {
                    return time;
                }
            }
        }
        return default(TimeSpan);
    }
