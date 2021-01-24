    bool CheckIsDirectlyInherited(Type obj, Type[] baseTypes)
    {
        if (obj.BaseType == null)
            return false;
        var objGenericDefinition = obj.BaseType;
        if (objGenericDefinition.IsGenericType)
        {
            objGenericDefinition = objGenericDefinition.GetGenericTypeDefinition();
        }
        foreach (Type baseType in baseTypes)
        {
            var baseTypeDefinition = baseType;
            if (baseTypeDefinition.IsGenericType)
                baseTypeDefinition = baseType.GetGenericTypeDefinition();
            if (objGenericDefinition == baseTypeDefinition)
                return true;
        }
        return false;
    }
