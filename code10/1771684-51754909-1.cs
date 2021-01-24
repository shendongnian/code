     public static DataTable ToDataTable<T>(List<T> items)
            {
    
                DataTable dataTable = new DataTable(typeof(T).Name);
    
                //Get all the properties
    
                PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                if (Props.Length > 0)
                {
                    foreach (PropertyInfo prop in Props)
                    {
                        if (GetDefault(prop.PropertyType.FullName) != null)
                        {
                            //Setting column names as Property names
                            dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                        }
                    }
                }
                else
                {
                    dataTable.Columns.Add("myColName");
                }
                foreach (T item in items)
                {
                    if (item != null)
                    {
                        DataRow dr = dataTable.NewRow();
                        if (Props.Length > 0)
                        {
                            foreach (PropertyInfo prop in Props)
                            {
                                if (GetDefault(prop.PropertyType.FullName) != null)
                                {
                                    //inserting property values to datatable rows
                                    dr[prop.Name] = prop.GetValue(item, null) ?? GetDefault(prop.PropertyType.FullName);
                                }
                            }
                        }
                        else
                        {
                                //inserting property values to datatable rows
                                dr[0] = item;
                        }
    
                        dataTable.Rows.Add(dr);
                    }
                }
    
                //put a breakpoint here and check datatable
    
                return dataTable;
    
            }
    
            public static object GetDefault(string dataType)
            {
    
                if (dataType.Contains("System.String"))
                {
                    return string.Empty;
                }
                if (dataType.Contains("System.Boolean"))
                {
                    return false;
                }
                if (dataType.Contains("System.Decimal"))
                {
                    return 0.0;
                }
                if (dataType.Contains("System.DateTime"))
                {
                    return DateTime.MinValue;
                }
                if (dataType.Contains("System.Int64"))
                {
                    return 0;
                }
                if (dataType.Contains("System.Guid"))
                {
                    return null;
                }
                if (dataType.Contains("System.Int16"))
                {
                    return 0;
                }
                if (dataType.Contains("Int32"))
                {
                    return 0;
    
                }
                if (dataType.Contains("System.Object"))
                {
                    return null;
                }
    
                return null;
            }
