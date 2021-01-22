    public static void Convert<T>(this DataColumn column, Func<object, T> conversion)
    {
        foreach(DataRow row in column.Table.Rows)
        {
            row[column] = conversion(row[column]);
        }
    }
