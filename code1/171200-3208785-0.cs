    public TestReflection(string assembly)
    {
        Assembly testAssembly = Assembly.LoadFrom(assembly); // or .LoadFile() here
        foreach (Type type in testAssembly.GetTypes())
        {
            if (type.IsSubclassOf(typeof(System.Web.Services.WebService)))
            {
                foreach (MethodInfo methodInfo in type.GetMethods())
                {
                    if (Attribute.GetCustomAttribute(methodInfo, typeof(System.Web.Services.WebMethodAttribute)) != null)
                    {
                        Console.WriteLine(methodInfo.Name);
                    }
                }
            }
        }
    }
