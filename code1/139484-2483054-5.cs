    private static bool CheckIfAnonymousType(Type type)
    {
        if (type == null)
            throw new ArgumentNullException("type");
        
        // HACK: The only way to detect anonymous types right now.
        return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
            && type.IsGenericType && type.Name.Contains("AnonymousType")
            && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
            && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
    }
