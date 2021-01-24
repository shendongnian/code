    string json =
        "[[[\"Text 1.A\",\"Text 1.B\",null,null,3],[\"Text 2.A\",\"Text 2.B\",null,null,1],[\"Text 3.A\",\"Text 3.B\",null,null,3],[\"Text 4.A\",\"Text 4.B\",null,null,3]],null,\"en\"]";
    
    var tokens = JsonConvert.DeserializeObject<JToken[]>(json);
    var subArray = tokens[0].ToObject<JToken[]>();
    var aTexts = subArray.Select(a =>
    {
        var arr = a.ToObject<object[]>();
        return (string)arr[0];
    }).ToArray();
