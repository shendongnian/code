    public static DataTable ListToDataTable<T>(IList<T> data)
            {
                DataTable table = new DataTable();
    
                //special handling for value types and string
                if (typeof(T).IsValueType || typeof(T).Equals(typeof(string)))
                {
    
                    DataColumn dc = new DataColumn("Value");
    
                    table.Columns.Add(dc);
    
                    foreach (T item in data)
                    {
                        DataRow dr = table.NewRow();
                        dr[0] = item;
    
                        table.Rows.Add(dr);
                    }
                }
                else
                {
                    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
                    
                    foreach (PropertyDescriptor prop in properties)
                    {
                        table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                    }
    
                    foreach (T item in data)
                    {
                        DataRow row = table.NewRow();
                        foreach (PropertyDescriptor prop in properties)
                        {
                            try
                            {
                                row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                            }
                            catch (Exception ex)
                            {
                                row[prop.Name] = DBNull.Value;
                            }
    
                        }
                        table.Rows.Add(row);
                    }
                }
                return table;
    
            }
