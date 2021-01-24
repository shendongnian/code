    public static T Parse<T>(string json, string key)
    {
        var rss = JObject.Parse(json);
        JToken jtoken = null;
        foreach (var k in key.Split('.'))
        {
            if (jtoken != null)
                jtoken = jtoken[k];
            else jtoken = rss[k];
        }
        return jtoken.ToObject<T>();
    }
    // then call the method 
    List<Country> countries = Parse<List<Country>>(json, "data.countries");
