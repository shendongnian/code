    public IEnumerable<Type> GetTypesWithAttribute(Assembly assembly)
    {
        return assembly.GetTypes()
            .Where(type => type.IsDefined(typeof(SerializableAttribute), false));
    }
