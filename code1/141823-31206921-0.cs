    public static class TypeExtensions
    {
        public static PropertyInfo GetSubProperty(this Type type, string treeProperty, object givenValue)
        {
            var properties = treeProperty.Split('.');
            var value = givenValue;
            foreach (var property in properties.Take(properties.Length - 1))
            {
                value = value.GetType().GetProperty(property).GetValue(value);
                if (value == null)
                {
                    return null;
                }
            }
            return value.GetType().GetProperty(properties[properties.Length - 1]);
        }
        public static object GetSubPropertyValue(this Type type, string treeProperty, object givenValue)
        {
            var properties = treeProperty.Split('.');
            return properties.Aggregate(givenValue, (current, property) => current.GetType().GetProperty(property).GetValue(current));
        }
    }
