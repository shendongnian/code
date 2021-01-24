    public static string GetName(object obj)
    {
        string json = JsonConvert.SerializeObject(obj);
        string result = JsonConvert.DeserializeAnonymousType(json, new { Name = "" })?.Name;
        return result;
    }
