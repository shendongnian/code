    using System.Reflection;
    private Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
    {
        return 
          assembly.GetTypes()
                  .Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                  .ToArray();
    }
