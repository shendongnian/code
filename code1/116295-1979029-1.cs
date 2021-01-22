    foreach (Type type in assembly.GetTypes())
    {
        if (type.GetCustomAttributes(typeof(..., false)).Length == 0)
        {
            continue;
        }
        ConstructorInfo ci = type.TypeInitializer;
        if (ci != null)
        {
             ci.Invoke(null);
        }
    }
