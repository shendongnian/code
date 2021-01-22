    public TestReflection(string assembly)
    {
        Assembly testAssembly = Assembly.LoadFrom(assembly);
        Type sType = testAssembly.GetType("NamespaceOfYourClass.NameOfYourClassHere", true, true);
        MethodInfo[] methodInfos = sType.GetMethods();
        foreach (MethodInfo methodInfo in methodInfos)
        {
            Console.WriteLine(methodInfo.Name);
        }
    }
