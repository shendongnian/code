    public static TInput SetValueByPropertyName<TInput>(TInput obj, string name, string value)
            {
                PropertyInfo prop = obj.GetType().GetProperty(name);
                if (null != prop && prop.CanWrite)
                {
                    if (prop.PropertyType != typeof(String))
                    {
                        prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), null);
                    }
                    else
                    {
                        prop.SetValue(obj, value, null);
                    }
                }
                return obj;
            }
