    TableQuery<UserTableEntity> existQuery = new TableQuery<UserTableEntity>().Where(
        TableQuery.GenerateFilterCondition("Email", QueryComparisons.Equal, Email));
    var queryResult = table.ExecuteQuerySegmentedAsync(existQuery, null).Result.Results;
    if (queryResult.Count == 0)
    {
        var attributes = new System.Attribute[]
        {
            new StorageAccountAttribute("TabbrDevCosmosDb"),
            new TableAttribute("Users")
        };
        var output = await binder.BindAsync<IAsyncCollector<UserTableEntity>>(attributes);
        await output.AddAsync(NewUser);
        return new OkObjectResult(JsonConvert.SerializeObject(NewUser));
    }
    else
    {
        return new BadRequestObjectResult("Already exists");
    }
