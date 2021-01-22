    IEnumerable<Type> AllTypes(Assembly assembly)
    {
        foreach (Type type in assembly.GetTypes())
        {
            yield return type;        
            foreach (Type nestedType in type.GetNestedTypes())
            {
                yield return nestedType;
            }
        }
    }
