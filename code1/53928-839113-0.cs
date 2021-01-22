    public Boolean IsImmutable(Type type)
    {
        BindingFlags flags = BindingFlags.Instance |
                             BindingFlags.NonPublic |
                             BindingFlags.Public;
        return type.GetFields(flags).All(f => f.IsInitOnly) &&
               type.GetProperties(flags).All(f => !f.CanWrite);
    }
