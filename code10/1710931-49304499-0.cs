    if (type.IsArray)
    {
        if (type.GetArrayRank() != 1)
        {
            return true;
        }
        Type elementType = type.GetElementType();
        if (elementType.IsArray)
        {
            return true;
        }
        return IsComplexType(elementType);
    }
