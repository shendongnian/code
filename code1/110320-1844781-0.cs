    public static bool TypeComparesProperties(Type t)
    {
        Type equatableInterface = typeof(IEquatable<>);
        if (t.GetInterface(equatableInterface.Name) != null)
        {
            return true;
        }
        else
        {
            Type objectClass = typeof(Object);
            MethodInfo equalsMethod = t.GetMethod("Equals", new Type[] { typeof(object) });
            return equalsMethod.DeclaringType != objectClass;
        }
    }
