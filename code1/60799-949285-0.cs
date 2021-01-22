    using System.Reflection;
    private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return assembly.GetTypes().Where(t => t.Namespace == nameSpace).ToArray();
    }
