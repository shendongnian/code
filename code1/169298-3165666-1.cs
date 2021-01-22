    public static IQueryable<IProjectObject> ExecuteQuery(Type ownerType, string name, params object[] args)
    {
        var query = typeof(ownerType)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f =>
                    (f.GetCustomAttributes(typeof(DynamicQueryAttribute), false).Length > 0)
                    && (f.Name.ToLowerInvariant() == name.ToLowerInvariant()))
            .Select(f => (Delegate) f.GetValue(null))
            .SingleOrDefault();
        if (query == null)
            return null;
        return (IQueryable<IReportObject>)query.DynamicInvoke(args);
    }
