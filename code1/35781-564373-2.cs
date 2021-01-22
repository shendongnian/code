    // remove "this" if not on C# 3.0 / .NET 3.5
    public static DataTable ToDataTable<T>(this IList<T> data)
    {
        PropertyDescriptorCollection props =
            TypeDescriptor.GetProperties(typeof(T));
        DataTable table = new DataTable();
        for(int i = 0 ; i < props.Count ; i++)
        {
            PropertyDescriptor prop = props[i];
            table.Columns.Add(prop.Name, prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(item);
            }
            table.Rows.Add(values);
        }
        return table;        
    }
