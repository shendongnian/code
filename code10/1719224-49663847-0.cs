    var strings = new List<string> {
        "example.string.1",
        "example.string.2",
        "example.anotherstring.1",
    };
    var result = strings.Aggregate(new Dictionary<string, Object>(), (acc, s) =>
    {
        var level = acc;
        foreach(var segment in s.Split('.'))
        {
            if (!level.ContainsKey(segment))
            {
                var child = new Dictionary<string, Object>();
                level.Add(segment, child);
            }
            level = (level[segment] as Dictionary<string, Object>);
        }
        return acc;
    });
    var json = JsonConvert.SerializeObject(result, Formatting.Indented);
