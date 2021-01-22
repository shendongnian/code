    public static void Main(string[] args)
    {
        printAllPublicPropertiesInCurrentAppDomain(typeof(string));
    }
    private static void printAllPublicPropertiesInCurrentAppDomain(Type typeToFind)
    {
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (Type type in assembly.GetTypes())
            {
                foreach (PropertyInfo info in type.GetProperties())
                {
                    if (info.PropertyType == typeToFind)
                    {
                        Console.WriteLine("Assembly: {0}, Type: {1}, Property: {2}", assembly.GetName().Name, type.Name, info.Name);
                    }
                }
            }
        }
    }
