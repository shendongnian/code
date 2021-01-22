    public static bool IsEmpty(this DataRow row)
    {
        return row == null || row.ItemArray.All(i => i.IsNullEquivalent());
    }
    public static bool IsNullEquivalent(this object value)
    {
        return value == null
               || value is DBNull
               || string.IsNullOrWhiteSpace(value.ToString());
    }
