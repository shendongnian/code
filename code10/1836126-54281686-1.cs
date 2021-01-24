    var type = typeof(IPropertyEditor);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => p.IsClass && !p.IsAbstract && type.IsAssignableFrom(p));
    foreach (var item in types)
    {
        string html = (string)item.GetMethod("GetHTML").Invoke(Activator.CreateInstance(item, null), null);
    }
