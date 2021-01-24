    public static EnumToDictionary<string, string> EnumToDictionary<T>() where T: Enum
    {
        var res = Enum.GetValues(typeof(T)).Cast<T>()
            .ToDictionary(e => Convert.ToInt32(e).ToString(), e => e.ToString());
        return res;
    }
