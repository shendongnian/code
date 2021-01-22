        public static object FollowPropertyPath(object value, string path)
        {
            Type currentType = value.GetType();
            object obj = value;
            foreach (string propertyName in path.Split('.'))
            {
                PropertyInfo property = currentType.GetProperty(propertyName);
                obj = property.GetValue(obj, null);
                currentType = obj.GetType(); //property.PropertyType;
            }
            return obj;
        }
