    public static class BuilderExtension
    {
        public static IDataExtractor<T> WithAllProperties<T>(this IDataExtractor<T> extractor)
        {
            var properties = typeof(T).GetProperties();
            foreach (var propertyInfo in properties)
            {
                var parameter = Expression.Parameter(propertyInfo.DeclaringType);
                var property = Expression.Property(parameter, propertyInfo);
                var lambda = Expression.Lambda<Func<T, object>>(property, parameter);
                extractor = extractor.WithProperty(lambda);
            }
            return extractor;
        }
    }
