    var data = ((JObject)json.Results).Children().ToArray();
    
    foreach (JProperty item in data)
    {
        var childss = item.Value.Children().ToArray();
    
        foreach (JProperty item2 in childss)
        {
            dynamic sub = item2.Value;
            string hmm = sub.value1;
        }
    }
