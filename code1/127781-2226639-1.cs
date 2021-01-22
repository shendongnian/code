    public static string DictToQueryString(Dictionary<string, string> data) { 
        return String.Join(
            "&",
            data.Select(kvp => String.Format("{0}={1}", kvp.Key, kvp.Value))
                .ToArray()
        );
