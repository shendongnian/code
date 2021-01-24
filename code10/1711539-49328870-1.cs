    public static Dictionary<string, string> EnumDisplayNameDictionary<TEnum>(this Enum @enum)
    {
        var returnDict = new Dictionary<string, string>(); 
        foreach (var item in Enum.GetValues(typeof(TEnum)))
        {
            returnDict.Add(item.ToString(), ((Enum)item).GetDisplayName());
        }
    
        return returnDict;
    }
