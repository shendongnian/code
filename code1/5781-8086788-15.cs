    public static Dictionary<int, string> EnumNamedValues<T>() where T : System.Enum
    {
        var result = new Dictionary<int, string>();
        var values = Enum.GetValues(typeof(T));
        foreach (int item in values)
            result.Add(item, Enum.GetName(typeof(T), item));
        return result;
    }
