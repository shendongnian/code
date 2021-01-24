    public static class TypeExtensions
    {
        public static IEnumerable<string> GetFullPropertyNames(this Type type, string propertyName)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (String.IsNullOrWhiteSpace(propertyName))
                throw new ArgumentNullException(nameof(propertyName));
            return GetFullPropertyNamesImpl(type, propertyName, new HashSet<Type>());
        }
        private static IEnumerable<string> GetFullPropertyNamesImpl(Type type, string propertyName, ICollection<Type> visitedTypes)
        {
            if (visitedTypes.Contains(type))
                yield break;
            visitedTypes.Add(type);
            var matchingProperty = type.GetProperty(propertyName);
            if (matchingProperty != null)
            {
                yield return matchingProperty.Name;
            }
            foreach (var property in type.GetProperties())
            {
                var matches = GetFullPropertyNamesImpl(property.PropertyType, propertyName, visitedTypes);
                foreach (var match in matches)
                {
                    yield return $"{property.Name}.{match}";
                }
            }
        }
    }
