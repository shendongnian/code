    public static async Task<T> GetById<T>(this IQueryable<T> entities, Expression<Func<T, long>> propertySelector, long id)
    {
       var member = propertySelector.Body as MemberExpression;
    
       var property = member.Member as PropertyInfo;
       var parameter = Expression.Parameter(typeof(T));
    
       var expression = Expression.Lambda<Func<T, bool>>(Expression.Equal(Expression.Constant(id), Expression.Property(parameter, property)), parameter);
    
       return await entities.FirstOrDefaultAsync(expression);
    }
