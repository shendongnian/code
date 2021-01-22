    public T create(object obj)
    {  // simplified for illustration
        var bindings = obj as IDictionary<string, object>;
        Type type = typeof(T);
        var func = Expression.Lambda<Func<T>>(Expression.MemberInit(
            Expression.New(type),
            from pair in bindings
            let member = type.GetMember(pair.Key).Single()
            select (MemberBinding)Expression.Bind(member, Expression.Constant(pair.Value))));
        return func.Compile().Invoke();
    }
