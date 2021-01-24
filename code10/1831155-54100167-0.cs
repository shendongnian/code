    client.IndexDocument(new MyEntity 
    {
        SomeProperty = new Dictionary<string, UserQuery.MyDto>
        {
            { "field_1", new MyDto { Name = "foo" } },
            { "field_2", new MyDto { Name = "bar" } }
        }
    });
