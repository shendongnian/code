    foreach (PropertyInfo info in properties)
         {
             if (info.PropertyType.IsValueType || info.PropertyType == typeof(string))
             {
                  dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
             }
         }
