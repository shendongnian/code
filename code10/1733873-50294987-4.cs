    public static IQueryable<T> SelectExcept<T, TKey>(this IQueryable<T> sequence,
        Expression<Func<T, TKey>> excluder)
    {
        List<string> excludedProperties = new List<string>();
        if (excluder.Body is MemberExpression memberExpression)
        {
            excludedProperties.Add(memberExpression.Member.Name);
        }
        else if (excluder.Body is NewExpression anonymousExpression)
        {
            excludedProperties.AddRange(anonymousExpression.Members.Select(m => m.Name));
        }
        var includedProperties = typeof(T).GetProperties()
            .Where(p => !excludedProperties.Contains(p.Name));
        return sequence.Select(x => Selector(x, includedProperties));
    }
    private static T Selector<T>(T obj, IEnumerable<PropertyInfo> properties)
    {
        var instance = Activator.CreateInstance<T>();
        foreach (var property in properties)
            property.SetValue(instance, property.GetValue(obj), null);
        return instance;
    }
