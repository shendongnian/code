    public static class ReflectionExtensions
    {
        public static ICollectionPropertyConfiguration<T> WithAllProperties<T>(
            this IDataExtractor<T> extractor) where T : class, new() =>
            typeof(T)
            .GetProperties()
            .Aggregate(extractor, ExtractProperty) as ICollectionPropertyConfiguration<T>;
        private static string ToColumn(this PropertyInfo property) =>
            ((ColumnAttribute)property.GetCustomAttributes(typeof(ColumnAttribute), true)
                .First()).Column;
        private static IDataExtractor<T> ExtractProperty<T>(IDataExtractor<T> extractor,
            PropertyInfo property) where T : class, new()
        {
            if (property.PropertyType == typeof(string))
                return extractor.WithProperty(ExpressionGenerator<T>.GetStringProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(int))
                return extractor.WithProperty(ExpressionGenerator<T>.GetIntProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(int?))
                return extractor.WithProperty(ExpressionGenerator<T>.GetNullableIntProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(DateTime))
                return extractor.WithProperty(ExpressionGenerator<T>.GetDateTimeProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(DateTime?))
                return extractor.WithProperty(ExpressionGenerator<T>.GetNullableDateTimeProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(bool))
                return extractor.WithProperty(ExpressionGenerator<T>.GetBooleanProperty(property), property.ToColumn());
            if (property.PropertyType == typeof(bool?))
                return extractor.WithProperty(ExpressionGenerator<T>.GetNullableBooleanProperty(property), property.ToColumn());
            throw new ArgumentException($"Unknown type {property.PropertyType}");
        }
        private static class ExpressionGenerator<T>
        {
            public static Expression<Func<T, string>> GetStringProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, string>>(GetMember(property), Parameter);
            public static Expression<Func<T, int>> GetIntProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, int>>(GetMember(property), Parameter);
            public static Expression<Func<T, int?>> GetNullableIntProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, int?>>(GetMember(property), Parameter);
            public static Expression<Func<T, DateTime>> GetDateTimeProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, DateTime>>(GetMember(property), Parameter);
            public static Expression<Func<T, DateTime?>> GetNullableDateTimeProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, DateTime?>>(GetMember(property), Parameter);
            public static Expression<Func<T, bool>> GetBooleanProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, bool>>(GetMember(property), Parameter);
            public static Expression<Func<T, bool?>> GetNullableBooleanProperty(PropertyInfo property) =>
                Expression.Lambda<Func<T, bool?>>(GetMember(property), Parameter);
            private static readonly ParameterExpression Parameter =
                Expression.Parameter(typeof(T), "p");
            private static MemberExpression GetMember(PropertyInfo property) =>
                Expression.Property(Parameter, property.Name);
        }
    }
