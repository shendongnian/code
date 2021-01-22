    Assembly assembly = Assembly.LoadFile(@"test.dll");
    foreach (Type type in assembly.GetTypes())
    {
        if (type.IsClass)
        {
            MethodInfo method = type.GetMethod("OnStart",
                BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                ...
            }
        }
    }
