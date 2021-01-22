    public class ActiveRecordCustomBase<T> : ActiveRecordBase<T>
        {
            public static string GetPropertyColumnName(string propertyName)
            {
                System.Reflection.PropertyInfo property = typeof(T).GetProperty(propertyName);
                object[] attributes = property.GetCustomAttributes(false);
    
                if (attributes != null)
                {
                    foreach (object attr in attributes)
                    {
                        if (attr is PrimaryKeyAttribute)
                        {
                            return ((PrimaryKeyAttribute)attr).Column;
                        }
                        else if (attr is PropertyAttribute)
                        {
                            return ((PropertyAttribute)attr).Column;
                        }
                    }
                }
                return null;
            }
        }
