    foreach (Type type in assembly.GetTypes())
    {
        foreach (MethodInfo method in type.GetMethods(BindingFlags.Public |
            BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance))
        {
            Console.WriteLine("{0} {1}{2}.{3}", GetFriendlyAccess(method),
                method.IsStatic ? "static " : "", type.Name, method.Name);
        }
    }
