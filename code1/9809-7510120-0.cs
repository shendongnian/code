    public static string StringFormat(string format, object source)
    {
        var matches = Regex.Matches(format, @"\{(.+?)\}");
        List<string> keys = (from Match matche in matches select matche.Groups[1].Value).ToList();
        
        return keys.Aggregate(
            format,
            (current, key) =>
            {
                int colonIndex = key.IndexOf(':');
                return current.Replace(
                    "{" + key + "}",
                    colonIndex > 0
                        ? DataBinder.Eval(source, key.Substring(0, colonIndex), "{0:" + key.Substring(colonIndex + 1) + "}")
                        : DataBinder.Eval(source, key).ToString());
            });
    }
