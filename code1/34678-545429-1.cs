    sealed class Tuple<T1, T2>
    {
        public Tuple() {}
        public Tuple(T1 value1, T2 value2) {Value1 = value1; Value2 = value2;}
        public T1 Value1 {get;set;}
        public T2 Value2 {get;set;}
    }
    public static List<T> Convert<T>(DataTable table)
        where T : class, new()
    {
        List<Tuple<DataColumn, PropertyInfo>> map =
            new List<Tuple<DataColumn,PropertyInfo>>();
        foreach(PropertyInfo pi in typeof(T).GetProperties())
        {
            ColumnAttribute col = (ColumnAttribute)
                Attribute.GetCustomAttribute(pi, typeof(ColumnAttribute));
            if(col == null) continue;
            if(table.Columns.Contains(col.FieldName))
            {
                map.Add(new Tuple<DataColumn,PropertyInfo>(
                    table.Columns[col.FieldName], pi));
            }
        }
        List<T> list = new List<T>(table.Rows.Count);
        foreach(DataRow row in table.Rows)
        {
            if(row == null)
            {
                list.Add(null);
                continue;
            }
            T item = new T();
            foreach(Tuple<DataColumn,PropertyInfo> pair in map) {
                object value = row[pair.Value1];
                if(value is DBNull) value = null;
                pair.Value2.SetValue(item, value, null);
            }
            list.Add(item);
        }
        return list;        
    }
