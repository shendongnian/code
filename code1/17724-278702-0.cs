    class Foo
    {
        public string Bar { get; set; }
    }
    static void Main()
    {
        var lambda = GetExpression<Foo>("Bar", "abc");
        Foo foo = new Foo { Bar = "aabca" };
        bool test = lambda.Compile()(foo);
    }
    static Expression<Func<T, bool>> GetExpression<T>(string propertyName, string propertyValue)
    {
        var parameterExp = Expression.Parameter(typeof(T), "type");
        var propertyExp = Expression.Property(parameterExp, propertyName);
        MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
        var someValue = Expression.Constant(propertyValue, typeof(string));
        var containsMethodExp = Expression.Call(propertyExp, method, someValue);
        return Expression.Lambda<Func<T, bool>>(containsMethodExp, parameterExp);
    }
