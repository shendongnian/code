    Type ti = typeof(IYourInterface);
    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
    {
        foreach (Type t in asm.GetTypes())
        {
            if (ti.IsAssignableFrom(t))
            {
                // here's your type in t
            }
        }
    }
