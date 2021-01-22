    public static DataTable ListToDataTable<T>(IList<T> lst)
    {
        currentDT = CreateTable<T>();
        Type entType = typeof(T);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
        foreach (T item in lst)
        {
            DataRow row = currentDT.NewRow();
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.PropertyType == typeof(Nullable<decimal>) || prop.PropertyType == typeof(Nullable<int>) || prop.PropertyType == typeof(Nullable<Int64>))
                {
                    if (prop.GetValue(item) == null)
                        row[prop.Name] = 0;
                    else
                        row[prop.Name] = prop.GetValue(item);
                }
                else
                    row[prop.Name] = prop.GetValue(item);                    
            }
            currentDT.Rows.Add(row);
        }
        return currentDT;
    }
 
    public static DataTable CreateTable<T>()
    {
        Type entType = typeof(T);
        DataTable tbl = new DataTable(DTName);
        PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entType);
        foreach (PropertyDescriptor prop in properties)
        {
            if (prop.PropertyType == typeof(Nullable<decimal>))
                 tbl.Columns.Add(prop.Name, typeof(decimal));
            else if (prop.PropertyType == typeof(Nullable<int>))
                tbl.Columns.Add(prop.Name, typeof(int));
            else if (prop.PropertyType == typeof(Nullable<Int64>))
                tbl.Columns.Add(prop.Name, typeof(Int64));
            else
                 tbl.Columns.Add(prop.Name, prop.PropertyType);
        }
        return tbl;
    }
