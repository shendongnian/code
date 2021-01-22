    public static class MapperExtensionClass
    {
            public static IEnumerable<MyClassType> ToMyClassTypeEnumerable(this DataTable table)
            {
                return table.AsEnumerable().Select(r => r.ToMyClassType());
            }
            public static MyClassType ToMyClassType(this DataRow row)
            {            
                return row.ToObject<MyClassType>();
            }
            
            public static T ToObject<T>(this DataRow row) where T: new()
            {
                T obj = new T();
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    if (row.Table.Columns.Contains(property.Name))
                    {
                        property.SetValue(obj, property.PropertyType.ToDefault(row[property.Name]));
                    }
                }
    
                return obj;
            }
    
    
            public static object ToDefault(this Type type, object obj)
            {
                if (type == null)
                    throw new Exception("Customized exception message");
    
                var method = typeof(MapperExtensionClass)
                    .GetMethod("ToDefaultGeneric", BindingFlags.Static | BindingFlags.Public);
    
                var generic = method.MakeGenericMethod(type);
    
                return generic.Invoke(null, new object[] { obj });            
            }
            
            public static T ToDefaultGeneric<T>(object obj)
            {
                if (obj == null || obj == DBNull.Value)
                {
                    return default(T); 
                }
                else
                {
                    return (T)obj;
                }
            }
    }
