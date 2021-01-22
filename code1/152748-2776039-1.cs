    var type = typeof(ISelfTester);
    var types = AppDomain.CurrentDomain.GetAssemblies()
        .Select(x => x.GetTypes())
        .SelectMany(x => x)
        .Where(x => x.Namespace == "My.Name.Space" && type.IsAssignableFrom(x));
    foreach (Type t in types)
    {
        ISelfTester obj = Activator.CreateInstance(t) as ISelfTester;
        obj.SelfTest();
    }
