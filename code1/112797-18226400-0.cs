     public static class Extensions
        {
            public static List<T> ToList<T>(this DataTable table) where T : new()
            {
                IList<PropertyInfo> properties = typeof(T).GetProperties().ToList();
                List<T> result = new List<T>();
    
                foreach (var row in table.Rows)
                {
                    var item = CreateItemFromRow<T>((DataRow)row, properties);
                    result.Add(item);
                }
    
                return result;
            }
    
            private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
            {
                T item = new T();
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(System.DayOfWeek))
                    {
                        DayOfWeek day = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), row[property.Name].ToString());
                        property.SetValue(item,day,null);
                    }
                    else
                    {
                        property.SetValue(item, row[property.Name], null);
                    }
                }
                return item;
            }
        }
