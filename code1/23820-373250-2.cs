    public static bool HasColumn(this IDataRecord r, string columnName)
    {
        try
        {
            return r.GetOrdinal(columnName) >= 0;
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
