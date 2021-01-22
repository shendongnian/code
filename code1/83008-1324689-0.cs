    static T GetValueOrDefault<T>(this DataRow row, string columnName)
    {
        if (!row.IsNull(columnName))
        {
            // Might want to support type conversion using Convert.ChangeType().
            return (T)row[columnName]
        }
        return default(T);
    }
