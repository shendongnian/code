    public static MethodInfo GetMethod<T>(this T instance,
        Expression<Func<T, object>> methodSelector)
    {
        // Note: this is a bit simplistic implementation. It will
        // not work for all expressions.
        return ((MethodCallExpression)methodSelector.Body).Method;
    }
    public static MethodInfo GetMethod<T>(this T instance,
        Expression<Action<T>> methodSelector)
    {
        return ((MethodCallExpression)methodSelector.Body).Method;
    }
    public static bool HasAttribute<TAttribute>(this MemberInfo member) 
        where TAttribute : Attribute
    {
        var attributes = member.GetCustomAttributes(typeof(TAttribute), true);
        return attributes.Length > 0;
    }
