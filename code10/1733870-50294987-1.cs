    public static IQueryable<T> SelectExcept<T, TKey>(this IQueryable<T> sequence, Expression<Func<T, TKey>> excluder)
    {
        var exProp = (excluder.Body as MemberExpression).Member.Name;
        var incProps = typeof(T).GetProperties().Where(p => p.Name != exProp);
        return sequence.Select(x => Selector(x, incProps));
    }
    private static T Selector<T>(T obj, IEnumerable<PropertyInfo> properties) 
    {
        var instance = Activator.CreateInstance(typeof(T));
        foreach (var property in properties)
            property.SetValue(instance, property.GetValue(obj), null);
        return (T)instance;
    }
