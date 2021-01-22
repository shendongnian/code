    foreach (Type type in assembly.GetTypes())
    {
        ConstructorInfo ci = type.TypeInitializer;
        if (ci != null)
        {
             ci.Invoke(null);
        }
    }
