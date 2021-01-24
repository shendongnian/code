    var doc = new Document();
    doc.Add("aaa", new DynamoDBBool(true));
    foreach(var item in doc)
    {
        var s = item.Value is DynamoDBBool ? item.Value.AsBoolean().ToString() : item.Value.ToString();
        Console.WriteLine($"{item.Key} : {s}");
    }
