    Assembly assembly = Assembly.LoadFile(@"test.dll");
    foreach (Type type in assembly.GetTypes())
    {
        if (type.IsClass)
        {
            MethodInfo method = type.GetMethod("OnStart",
                BindingFlags.Static | BindingFlags.Public);
            if (method != null)
            {
                method.Invoke(null, new Object[0]); // assumes no parameters
                break; // no need to look for more methods, unless you got multiple?
            }
        }
    }
