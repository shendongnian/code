    public TProperty GetPropertyFromDbValue<T, TProperty>(
        T obj,
        Expression<Func<T, TProperty>> property
    )
    {
        return property.Compile()(obj);
    }
