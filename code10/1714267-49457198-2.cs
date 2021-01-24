    var dto = new ModelBaseCollectionDTO
    {
        Models = new List<ModelBase>()
        {
            new ApplicationLoggingModel { Test = "test value" },
            new AnotherModel { AnotherTest = "another test value" },
        },
    };
    var json = JsonConvert.SerializeObject(dto, Formatting.Indented);
