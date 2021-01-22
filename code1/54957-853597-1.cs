    public static string Encode(IEnumerable<string> strings)
    {
        return string.Join("&", strings.Select(s => HttpUtility.UrlEncode(s)).ToArray());
    }
    public static IEnumerable<string> Decode(string list)
    {
        return list.Split('&').Select(s => HttpUtility.UrlDecode(s));
    }
