    public static DataTable CreateDataSource<TEnum>()
    {
        Type enumType = typeof(TEnum);
        if (enumType.IsEnum) // It is not possible to do "where TEnum : Enum"
        {
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Value", enumType);
            foreach (var value in Enum.GetValues(enumType))
            {
                table.Rows.Add(Enum.GetName(enumType, value), value);
            }
            return table;
        }
        else
            throw new ArgumentException("Type TEnum is not an enumeration.");
    }
