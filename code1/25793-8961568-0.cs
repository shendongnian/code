    public Dictionary<string, string> ParseJSON(string s)
    {
        Regex r = new Regex("\"(?<Key>[\\w]*)\":\"?(?<Value>([\\s\\w\\d\\.\\\\\\-/:_\\+]+(,[,\\s\\w\\d\\.\\\\\\-/:_\\+]*)?)*)\"?");
        MatchCollection mc = r.Matches(s);
        Dictionary<string, string> json = new Dictionary<string, string>();
        foreach (Match k in mc)
        {
            json.Add(k.Groups["Key"].Value, k.Groups["Value"].Value);
        }
        return json;
    }
