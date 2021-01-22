    public static string XmlEncode(string unescaped)
    {
        if (unescaped == null) return null;
        return JsonConvert.SerializeObject(unescaped); ;
    }
    public static string XmlDecode(string escaped)
    {
        if (escaped == null) return null;
        return JsonConvert.DeserializeObject(escaped, typeof(string)).ToString();
    }
