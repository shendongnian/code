    public TProperty GetPropertyFromDbValue<T, TProperty>(
        T obj,
        Expression<Func<T, TProperty>> expression
    )
    {
        return expression.Compile()(obj);
    }
