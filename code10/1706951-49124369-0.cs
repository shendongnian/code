    static async Task SimpleSelectAsync(Client client)
    {
        var queryBuilder = client.GetRelationalEntitySet<ProductCategory>()
            .CreateQueryBuilder();
        var query = queryBuilder
            .Where(pc => pc.Name == "Electronics")
            .OrderByAscending(pc => new object[] { pc.CategoryId })
            .Project( /* REMOVE THIS STUFF?.. pc => pc.SelectField(f => f.CategoryId)
                .SelectField(f => f.Name)
                .SelectField(f => f.Description) */ );
        // Execute the query:
        OperationResult<IReadOnlyList<ProductCategory>> queryResult = null;
        var executor = client.CreateRelationalBatchExecuter(
            RelationalBatchExecutionMode.Transactional)
            .Query(query, out queryResult);
        await executor.ExecuteAsync();
        foreach (var pc in queryResult.Result)
        {
            Console.WriteLine(pc.Name);
        }
    }
