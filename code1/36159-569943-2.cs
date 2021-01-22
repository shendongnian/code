    public static string Surround(
        string original, string head, string tail, string match)
    {
        return Regex.Replace(original, match, head + "$0" + tail);
    }
