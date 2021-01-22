    public static Expression<Func<T, bool>> AdHoc<T>
                (string columnName, object compValue)
    {
        //  Determine type of parameter
        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
        //  Target to compare to
        Expression property = Expression.Property(parameter, columnName);
        //  The value to match
        Expression constant = Expression.Constant(compValue, compValue.GetType());
    
        Expression equality = Expression.Equal(property, constant);
        Expression<Func<T, bool>> predicate =
        Expression.Lambda<Func<T, bool>>(equality, parameter);
    
        return predicate;
    }
