    ...
    
    using (HttpContent content = response.Content)
    {
        var jsonString = await response.Content.ReadAsStringAsync();
        //1
        JToken jToken = JToken.Parse(jsonString);
        //2
        JObject[] items = jToken.ToObject<JObject[]>();
    
        foreach (var item in items)
        {
            Console.WriteLine(item["distance"]);
            Console.WriteLine(item["latt_long"]);
            Console.WriteLine(item["location_type"]);
            Console.WriteLine(item["title"]);
            Console.WriteLine(item["woeid"]);
            Console.WriteLine();
        }
    
        Console.Read();
    }
