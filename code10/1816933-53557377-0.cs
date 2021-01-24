     public static IOrderedQueryable<TSource> ApplyOrderDirection<TSource>(this IQueryable<TSource> source, string attributeName, int sortOrder)
            {
                if (String.IsNullOrEmpty(attributeName))
                {
                    return source as IOrderedQueryable<TSource>;
                }
    
                var propertyInfo = typeof(TSource).GetProperty(attributeName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
    
                if (propertyInfo == null)
                {
                    throw new ArgumentException("ApplyOrderDirection: The associated Attribute to the given AttributeName could not be resolved", attributeName);
                }
    
                Expression<Func<TSource, object>> orderExpression = x => propertyInfo.GetValue(x, null);
    
                if (sortOrder > 0)
                {
                    return source.OrderBy(orderExpression);
                }
                else
                {
                    return source.OrderByDescending(orderExpression);
                }
            }
