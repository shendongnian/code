    public static Type FixTypeReference(this Type type)
    {
        if (type.FullName != null)
            return type;
        string typeQualifiedName = type.DeclaringType != null
            ? type.DeclaringType.FullName + "+" + type.Name + ", " + type.Assembly.FullName
            : type.Namespace + "." + type.Name + ", " + type.Assembly.FullName;
        return Type.GetType(typeQualifiedName, true);
    }
