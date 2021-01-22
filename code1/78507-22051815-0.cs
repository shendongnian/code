    Enumerable.Range(1, 10).ToList().ToDataSet();
----------
    public static DataSet ToDataSet<T>(this IList<T> list)
    {
        var elementType = typeof(T);
        var ds = new DataSet();
        var t = new DataTable();
        ds.Tables.Add(t);
        if (elementType.IsValueType)
        {
            var colType = Nullable.GetUnderlyingType(elementType) ?? elementType;
            t.Columns.Add(elementType.Name, colType);
            
        } else
        {
            //add a column to table for each public property on T
            foreach (var propInfo in elementType.GetProperties())
            {
                var colType = Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType;
                t.Columns.Add(propInfo.Name, colType);
            }
        }
        //go through each property on T and add each value to the table
        foreach (var item in list)
        {
            var row = t.NewRow();
            if (elementType.IsValueType)
            {
                row[elementType.Name] = item;
            }
            else
            {
                foreach (var propInfo in elementType.GetProperties())
                {
                    row[propInfo.Name] = propInfo.GetValue(item, null) ?? DBNull.Value;
                }
            }
            t.Rows.Add(row);
        }
        return ds;
    }
