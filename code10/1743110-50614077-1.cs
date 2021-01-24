    string json = "{ \"application.data\":\"process\" }";
    var jObject = JsonConvert.DeserializeObject<JObject>(json);
    var jWithDot = jObject.Properties().Where(x => x.Name.Contains(".")).ToList();
    foreach (var j in jWithDot)
    {
        var names = j.Name.Split(".");
                
        var jProperty = new JProperty(names[0], new JObject(new JProperty(names[1], j.Value)));
        j.Replace(jProperty);
    }
    // { "application": { "data": "process" } }
    var newJson = jObject.ToString();
