    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
            {
                try
                {
                    List<T> list = new List<T>();
    
                    foreach (DataRow row in table.Rows)
                    {
                        T obj = new T();
    //change made at this line
                        foreach (var prop in obj.GetType().GetProperties())
                        {
                            try
                            {
                                PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                                propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                            }
                            catch
                            {
                                continue;
                            }
                        }
    
                        list.Add(obj);
                    }
    
                    return list;
                }
                catch
                {
                    return null;
                }
            }
