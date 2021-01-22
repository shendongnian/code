    public static DataTable ConvertToDataTable<T>(IList<T> list)
    {
        var dt = new DataTable();
        var properties = typeof(T).GetProperties();
        foreach (var pi in properties)
            dt.Columns.Add(pi.Name, pi.PropertyType);
        foreach (T element in list) {
            var row = dt.NewRow();
            foreach (var pi in properties)
                row[pi.Name] = pi.GetValue(element, null);
            dt.Rows.Add(row);
        }
        return dt;
    }
