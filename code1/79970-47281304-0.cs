    private static Dictionary<string, string> map = new Dictionary<string, string>();
    public static void put(string key, string value)
    {
        if (value == null) value = "null";
        map[key] = value;
    }
    public static string get(string key, string defaultValue)
    {
        try
        {
            return map[key];
        }
        catch (KeyNotFoundException e)
        {
            return defaultValue;
        }
    }
    public static string get(string key)
    {
        return get(key, "null");
    }
