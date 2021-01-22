    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T> list = new List<T>();
            foreach (var row in table.AsEnumerable())
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                        if (propertyInfo.PropertyType.IsEnum)
                        {
                            propertyInfo.SetValue(obj, Enum.Parse(propertyInfo.PropertyType, row[prop.Name].ToString()));
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }                          
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
