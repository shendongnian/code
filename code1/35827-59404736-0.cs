      private DataTable CreateDataTable(IList<T> item)
            {
                Type type = typeof(T);
                var properties = type.GetProperties();
    
                DataTable dataTable = new DataTable();
                foreach (PropertyInfo info in properties)
                {
                    dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
                }
    
                foreach (Tentity in item)
                {
                    object[] values = new object[properties.Length];
                    for (int i = 0; i < properties.Length; i++)
                    {
                        values[i] = properties[i].GetValue(entity);
                    }
    
                    dataTable.Rows.Add(values);
                }
                return dataTable;
            }
