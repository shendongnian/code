    public static class TypeExtensions
    {
        public static IEnumerable<string> GetFullPropertyNames(this Type type, string propertyName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            return GetFullPropertyNamesImpl(type, propertyName);
        }
        private static IEnumerable<string> GetFullPropertyNamesImpl(Type type, string propertyName)
        {
            var matchingProperty = type.GetProperty(propertyName);
            if (matchingProperty != null)
            {
                yield return matchingProperty.Name;
            }
            foreach (var property in type.GetProperties())
            {
                var matches = GetFullPropertyNamesImpl(property.PropertyType, propertyName);
                foreach (var match in matches)
                {
                    yield return $"{property.Name}.{match}";
                }
            }
        }
    }
