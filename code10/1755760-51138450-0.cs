    var list = new List<AttributeValue>
    {
        new AttributeValue(1, "Color", "Blue"),
        new AttributeValue(1, "Size", "30"),
        new AttributeValue(1, "Special", "Slim"),
        new AttributeValue(3, "Color", "Blue"),
        new AttributeValue(4, "Size", "30"),
        new AttributeValue(2, "Special", "Slim"),
        new AttributeValue(2, "Random", "Foo Foo")
    };
    
    // First we groupby the id and then for each group (which is essentialy a row now)
    // we'll create a new MyMappProducts containing the id and its attributes
    var result = list.GroupBy(av => av.Id)
                        .Select(g => new MyMappProducts
                        {
                            id = g.Key,
                            Attributes = g.ToDictionary(av => av.Attribute, av => av.Value)
                        })
                        .ToList();
