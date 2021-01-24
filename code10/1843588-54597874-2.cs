    List<PropertyInfo> properties = new List<PropertyInfo>();
    
    foreach (PropertyInfo info in type.GetProperties())
    {
        if (info.PropertyType.IsValueType || info.PropertyType == typeof(string))
        {
             dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
             properties.Add(info);
        }
    }
    foreach (T entity in list)
    {
         int i = 0;
         object[] values = new object[propCount];
         foreach (PropertyInfo info in properties)
         {
             values[i] = properties[i].GetValue(entity);
             i++;
         }
                
         dataTable.Rows.Add(values);
    }
