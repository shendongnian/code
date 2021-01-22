    public T DataRowToObject<T>(DataRow row) where T : new()
    {
        var properties = typeof(T).GetProperties().Where(p => p.CanWrite);
        var columns = row.Table.Columns.Cast<DataColumn>();
    
        // Match properties of T with DataTable columns
        var common =
            from p in properties
            from c in columns
            where c.ColumnName == p.Name
            && p.PropertyType.IsAssignableFrom(c.DataType)
            select p;
    
        T obj = new T();
        foreach (var prop in common)
        {
            if (!row.IsNull(prop.Name))
            {
                object value = row[prop.Name];
                prop.SetValue(obj, value, null);
            }
        }
        return obj;
    }
    ...
    MyClass[] objects = dataTable.AsEnumerable().Select(row => DataRowToObject(row)).ToArray();
