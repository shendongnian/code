    public static string MakeJsonLikeStr(object o)
    {
        string json = JsonConvert.SerializeObject(o);
        return json.Replace("{", "").Replace("}", "");
    }
