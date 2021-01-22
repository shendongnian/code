    public static string EncodeHtmlRequestBody(object data, string parent = null) {
        var keyValuePairs = new List<string>();
        var dict = new RouteValueDictionary(data);
        foreach (var pair in dict) {
            string key = parent == null ? pair.Key : parent + "." + pair.Key;
            var type = pair.Value.GetType();
            if (type.IsPrimitive || type == typeof(decimal) || type == typeof(string)) {
                keyValuePairs.Add(key + "=" + HttpUtility.HtmlEncode(pair.Value).Replace(" ", "+"));
            } else {
                keyValuePairs.Add(EncodeHtmlRequestBody(pair.Value, key));
            }
        }
        return String.Join("&", keyValuePairs);
    }
