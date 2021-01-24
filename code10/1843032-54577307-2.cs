    var doc = new Document();
    doc.Add("aaa", new DynamoDBBool(true));
    var dict = JsonConvert.DeserializeObject<IDictionary<string, string>>(doc.ToJson());
    foreach(var item in dict)
    {
        Console.WriteLine(item.Value);
    }
