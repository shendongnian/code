    public void Foo<T, P>(Expression<Func<T, P>> action)
    {
        Expression e = action.Body;
        MemberExpression me;
        while ((me = e as MemberExpression) != null)
        {
            string propertyName = me.Member.Name;
            Type propertyType = e.Type;
            Console.WriteLine(propertyName + ": " + propertyType);
            e = me.Expression;
        }
    }
