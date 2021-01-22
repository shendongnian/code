    public static IQueryable<TSource> SearchInText<TSource>(this IQueryable<TSource> source, string textToFind)
    {
        // Collect fields
        PropertyInfo[] propertiesInfo = source.ElementType.GetProperties();
        List<string> fields = new List<string>();
        foreach (PropertyInfo propertyInfo in propertiesInfo)
        {
            if (
                (propertyInfo.PropertyType == typeof(string)) ||
                (propertyInfo.PropertyType == typeof(int)) ||
                (propertyInfo.PropertyType == typeof(long)) ||
                (propertyInfo.PropertyType == typeof(byte)) ||
                (propertyInfo.PropertyType == typeof(short))
                )
            {
                fields.Add(propertyInfo.Name);
            }
        }
    
        ParameterExpression parameter = Expression.Parameter(typeof(TSource),     source.ElementType.Name);
    
        var property = typeof(TSource).GetProperty(fields[0]);
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var constantValue = Expression.Constant(textToFind);
        var equality = Expression.Call(Expression.Call(Expression.Property(parameter,     property), "ToUpper", null, null), typeof(string).GetMethod("Contains", new Type[] { typeof(string) }), Expression.Constant(textToFind.ToUpper()));
    
        return source.Where(Expression.Lambda<Func<TSource, bool>>(equality, parameter));
    }
