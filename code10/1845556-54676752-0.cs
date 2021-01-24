public static DataTable CreateDataTableFromAnyCollection<T>(IEnumerable<T> list)
    {
        Type type = typeof(T);
        var properties = type.GetProperties();
        DataTable dataTable = new DataTable();
        foreach (PropertyInfo info in properties)
        {
            dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
        }
        foreach (T entity in list)
        {
            object[] values = new object[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                values[i] = properties[i].GetValue(entity,null);
            }
            dataTable.Rows.Add(values);
        }
        return dataTable;
    }
and pass any type of object your LINQ query returning.
DataTable dt = CreateDataTableFromAnyCollection(query);
I hope this will help you. 
