    public static void IncludeProperties<T>(
        Expression<Func<T, object>> selectedProperties)
    {
        NewExpression ne = selectedProperties.Body as NewExpression;
        if (ne == null) throw new InvalidOperationException(
              "Object constructor expected");
        foreach (Expression arg in ne.Arguments)
        {
            MemberExpression me = arg as MemberExpression;
            if (me == null || me.Expression != selectedProperties.Parameters[0])
                throw new InvalidOperationException(
                    "Object constructor argument should be a direct member");
            Console.WriteLine("Accessing: " + me.Member.Name);
        }
    }
    static void Main()
    {
        IncludeProperties<IUser>(u => new { u.ID, u.LogOnName, u.HashedPassword });
    }
