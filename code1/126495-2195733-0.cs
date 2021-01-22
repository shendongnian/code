    public static IDictionary<String, Int32> ToDictionary(this Enum enumeration)
    {
        var map = new Dictionary<string, int>();
        var value = (int)(object)enumeration;
        var type = enumeration.GetType();
        foreach (int cur in Enum.GetValues(type))
        {
            if (0 != (cur & value))
            {
                map.Add(Enum.GetName(type, cur),cur);
            }
        }
        return map;
    }
