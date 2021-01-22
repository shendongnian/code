    public static DataTable ToDataTable<T>(this IEnumerable<T> items)
    {
        var tb = new DataTable(typeof(T).Name);
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach(var prop in props)
        {
            tb.Columns.Add(prop.Name, prop.PropertyType);
        }
    
        foreach (var item in items)
        {
            var values = new object[props.Length];
            for (var i=0; i<props.Length; i++)
            {
               values[i] = props[i].GetValue(item, null);
            }
    
            tb.Rows.Add(values);
        }
        return tb;
    }
