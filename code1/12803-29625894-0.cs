    public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
    {
        try
        {
            T tempT = new T();
            var tType = tempT.GetType();
            List<T> list = new List<T>();
            foreach (var row in table.Rows.Cast<DataRow>())
            {
                T obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    try
                    {
                        var propertyInfo = tType.GetProperty(prop.Name);
                        var rowValue = row[prop.Name];
                        if (rowValue is DateTime)
                        {
                            propertyInfo.SetValue(obj, rowValue, null);
                        }
                        else
                        {
                            propertyInfo.SetValue(obj, Convert.ChangeType(rowValue, propertyInfo.PropertyType), null);
                        }
                       
                    }
                    catch(Exception ex)
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
