    IEnumerable<MyDto> list = new List<MyDto>(); // This is the stuff you parsed
    var results = new Dictionary<string, MyDto>();
    foreach (var item in list) {
        var key = $"{item.SomeId1}|{item.SomeId2}";
        if (results.ContainsKey(key))
            foreach (var entry in item.JsonDictionary)
                results[key].JsonDictionary[entry.Key] = entry.Value;
        else results[key] = item;
    }
    list = results.Values;
