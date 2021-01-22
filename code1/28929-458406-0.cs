    public bool IsTypeDerivedFromGenericType(Type typeToCheck, Type genericType)
    {
        if (typeToCheck == typeof(object))
        {
            return false;
        }
        else if (typeToCheck == null)
        {
            return false;
        }
        else if (typeToCheck.IsGenericType && typeToCheck.GetGenericTypeDefinition() == genericType)
        {
            return true;
        }
        else
        {
            return IsTypeDerivedFromGenericType(typeToCheck.BaseType, genericType);
        }
    }
