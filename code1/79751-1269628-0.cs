    Type intType = typeof(IInterface);
    foreach (Type t in pluginAssembly.GetTypes())
    {
        if (intType.IsAssignableFrom(t))
        {
        }
    }
