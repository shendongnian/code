    public static string ToJsonArray(this Dictionary<string, string> dict)
    {
        var kvp = dict.Select(x => string.Format(@"""{0}"":""{1}""", x.Key, string.Concat(",", x.Value)));
        return string.Concat("{", string.Join(",", kvp), "}");
    }
    // Usage
    this.LangArray = this.Languages.ToJsonArray();
