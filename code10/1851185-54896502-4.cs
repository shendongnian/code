    result  test = JsonConvert.DeserializeObject<result>(Resource1.JSON);
            
    foreach(string key in test.Clients.Keys)
    {
        ExpandoObject obj = test.Clients[key];
        var dict = obj as IDictionary<string, object>;
        dynamic client = obj;
        if (dict.ContainsKey("id"))
            Console.WriteLine(client.id);
        if (dict.ContainsKey("name"))
            Console.WriteLine(client.name);
    }
