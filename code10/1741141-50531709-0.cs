    public TTranslateTo TranslateTo<TTranslateTo>()
    {
        var target = Activator.CreateInstance<TTranslateTo>();
        foreach (var p1 in GetObjectTypeProperties)
        {
            var p2 =
                target.GetType()
                    .GetProperties()
                    .FirstOrDefault(p => string.Equals(p.Name, p1.Name, StringComparison.CurrentCultureIgnoreCase) && p.PropertyType == p1.PropertyType);
            p2?.SetValue(target, p1.GetValue(this));
        }
        return target;
    }
    private IEnumerable<PropertyInfo> GetObjectTypeProperties => GetType()
        .GetProperties();
