            int propCount = 0;
            foreach (PropertyInfo info in properties)
                 {
                     if (info.PropertyType.IsValueType || info.PropertyType == typeof(string))
                         {
                              dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
                              propCount ++;
                         }
                     }
    
                    foreach (T entity in list)
                      {
                     object[] values = new object[propCount];
                     int i = 0;
                     foreach (PropertyInfo info in properties)
                     {
                         if (info.PropertyType.IsValueType || info.PropertyType == typeof(string))
                         {
                             values[i] = properties[i].GetValue(entity);
                             i++;
                         }
            
                        dataTable.Rows.Add(values);
                    }
                }
