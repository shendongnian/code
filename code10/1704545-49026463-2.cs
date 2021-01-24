    public static void SetMember<T>(Expression<Func<T>> memberExpression, T newVlaue)
    {
        var body = (MemberExpression)memberExpression.Body;
        var name = body.Member.Name; //text
        var newValueParam = Expression.Parameter(typeof(T));
        var newBody = Expression.Assign(body, newValueParam);
        var setter = Expression.Lambda<Action<T>>(newBody, newValueParam).Compile();
        setter(newVlaue); // Set with the new value 
    }
