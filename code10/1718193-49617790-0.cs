    Type type = Assembly.GetEntryAssembly()
        .DefinedTypes
        .Where(t => typeof(DbContext).IsAssignableFrom(t))
        .FirstOrDefault();
    object res = null;
    if (type != null) {
        res = Activator.CreateInstance(type, false);
    }
    return (DbContext)res;
