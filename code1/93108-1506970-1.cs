    [Test]
    public void TestReflectionOnlyLoadWithPartialName()
    {
        var l = ReflectionOnlyLoadWithPartialName("System.Windows.Forms");
        Assert.IsTrue(l.ReflectionOnly);
    }
    public Assembly ReflectionOnlyLoadWithPartialName(string partialName)
    {
        return ReflectionOnlyLoadWithPartialName(partialName, null);
    }
    public Assembly ReflectionOnlyLoadWithPartialName(string partialName, Evidence securityEvidence)
    {
        if (securityEvidence != null)
            new SecurityPermission(SecurityPermissionFlag.ControlEvidence).Demand();
        AssemblyName fileName = new AssemblyName(partialName);
        var assembly = nLoad(fileName, null, securityEvidence, null, null, false, true);
        if (assembly != null)
            return assembly;
        var assemblyRef = EnumerateCache(fileName);
        if (assemblyRef != null)
            return InternalLoad(assemblyRef, securityEvidence, null, true);
        return assembly;
    }
    private Assembly nLoad(params object[] args)
    {
        return (Assembly)typeof(Assembly)
            .GetMethod("nLoad", BindingFlags.NonPublic | BindingFlags.Static)
            .Invoke(null, args);
    }
    private AssemblyName EnumerateCache(params object[] args)
    {
        return (AssemblyName)typeof(Assembly)
            .GetMethod("EnumerateCache", BindingFlags.NonPublic | BindingFlags.Static)
            .Invoke(null, args);
    }
    private Assembly InternalLoad(params object[] args)
    {
        // Easiest to query because the StackCrawlMark type is internal
        return (Assembly)
            typeof(Assembly).GetMethods(BindingFlags.NonPublic | BindingFlags.Static)
            .First(m => m.Name == "InternalLoad" && m.GetParameters()[0].ParameterType == typeof(AssemblyName))
            .Invoke(null, args);
    }
