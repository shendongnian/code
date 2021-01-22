    var methods = AppDomain.CurrentDomain.GetAssemblies()
        .Select(x => x.GetTypes())
        .SelectMany(x => x)
        .Where(x => x.Namespace == "My.Name.Space")
        .Where(c => c.GetMethod("MethodName") != null)
        .Select(c => c.GetMethod("MethodName"));
    foreach (MethodInfo mi in methods)
    {
        var obj = Activator.CreateInstance(mi.DeclaringType);
        mi.Invoke(obj, null); // replace null with the appropriate arguments
    }
