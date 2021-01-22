    public static IEnumerable<T> EnumToList<T>()
    {
        Type enumType = typeof(T);
    
        // Can't use generic type constraints on value types,
        // so have to do check like this
        if (enumType.BaseType != typeof(Enum))
            throw new ArgumentException("T must be of type System.Enum");
    
        Array enumValArray = Enum.GetValues(enumType);
        List<T> enumValList = new List<T>(enumValArray.Length);
    
        foreach (int val in enumValArray)
        {
            enumValList.Add((T)Enum.Parse(enumType, val.ToString()));
        }
    
        return enumValList;
    }
