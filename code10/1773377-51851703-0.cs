    var client = new ElasticClient();
    var values = new List<dynamic>();
    dynamic obj = new System.Dynamic.ExpandoObject();
    obj.Id = "ABC";
    obj.SomeValue0 = "12";
    obj.SomeValue1 = 99;
    values.Add(obj);
    var descriptor = new BulkDescriptor();
    // Now i want to Index this List
    foreach (var doc in values)
    {
        descriptor.Index<object>(i => i
            .Index("abc")
            .Id((Id)doc.Id)
            .Document((object)doc));
    }
    client.Bulk(descriptor);
