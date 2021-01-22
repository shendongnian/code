    public static IQueryable GetAllEnumValues<T>()
    {
        IQueryable retVal = null;
        Type targetType = typeof(T);
        if(targetType.IsEnum)
        {
            retVal = Enum.GetValues(targetType).AsQueryable();
        }
 
        return retVal;
    }
