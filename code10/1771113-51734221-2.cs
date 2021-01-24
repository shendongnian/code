    services.AddSingleton<IDynamoDbClientAccessor, DynamoDbClientAccessor>();
    services.Configure<DynamoDbClientAccessorSettings>(c =>
    {
        c.Id = "YOUR ID";
        c.Password = "YOUR PASSWORD";
        c.Region = "YOUR REGION";
    });
