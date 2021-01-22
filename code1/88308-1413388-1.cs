    public Binding CreateBinding<TSource, TResult>(Expression<Func<TSource, TResult>> expression)
    {
        return new Binding(GetPropertyName(expression))
    }
    ...
    DisplayMember = CreateBinding((MyDataObject o) => o.FooProperty)
    ...
