    public static IEnumerable<T> EnumToList<T>()
        where T : struct
    {
        Type enumType = typeof(T);
    
        // Can't use generic type constraints on value types,
        // so have to do check like this
        if (enumType.BaseType != typeof(Enum))
            throw new ArgumentException("T must be of type System.Enum");
        Array enumValArray = Enum.GetValues(enumType);
        List<T> enumValList = new List<T>();
    
        foreach (T val in enumValArray)
        {
            enumValList.Add(val.ToString());
        }
    
        return enumValList;
    }
