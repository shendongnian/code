        public static bool AllPropertiesNotNull<T>(this T obj) where T : class
        {
            foreach (var prop in obj.GetType().GetProperties())
            {
                //See if our property is not a value type (value types can't be null)
                if (!prop.PropertyType.IsValueType)
                {
                    if (prop.GetValue(obj, null) == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
