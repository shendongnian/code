    public static class PropertyScanner
    {
        static Func<TType, bool> CreatePredicate<TType, TValue>(TValue value, IEqualityComparer<TValue> comparer)
        {
            var arg = Expression.Parameter(typeof(TType), "arg");
            Expression body = null;
            Expression<Func<TValue, TValue, bool>> compare = (val1, val2) => comparer.Equals(val1, val2);
            foreach (PropertyInfo property in typeof(TType).GetProperties(BindingFlags.Public))
            {
                if (property.PropertyType == typeof(TValue) || typeof(TValue).IsAssignableFrom(property.PropertyType))
                {
                    Expression prop = Expression.Equal(Expression.Invoke(compare, new Expression[]
                                           {
                                               Expression.Constant(value),
                                               Expression.Property(arg, property.Name)
                                           }),
                                                   Expression.Constant(0));
                    if (body == null)
                    {
                        body = prop;
                    }
                    else
                    {
                        body = Expression.OrElse(body, prop);
                    }
                }
            }
            return Expression.Lambda<Func<TType, bool>>(body, arg).Compile();
        }
        public static IEnumerable<TType> ScanProperties<TType, TValue>(this IEnumerable<TType> source, TValue value)
        {
            return ScanProperties<TType, TValue>(source, value, EqualityComparer<TValue>.Default);
        }
        public static IEnumerable<TType> ScanProperties<TType, TValue>(this IEnumerable<TType> source, TValue value, IEqualityComparer<TValue> comparer)
        {
            return source.Where(CreatePredicate<TType, TValue>(value, comparer));
        }
    }
