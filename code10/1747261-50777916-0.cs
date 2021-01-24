    public async Task<IEnumerable<TRes>> Query<T, TRes>(
            string docCollection,
            string partitionKey,
            Func<IOrderedQueryable<T>, IQueryable<TRes>> func,
            string continuationToken = null)
        {
            var queryable =
                CosmosClient.CreateDocumentQuery<T>(
                    CollectionUri(docCollection),
                    new FeedOptions
                    {
                        MaxItemCount = 100,
                        RequestContinuation = continuationToken,
                        EnableCrossPartitionQuery = false,
                        PartitionKey = new PartitionKey(partitionKey),
                        PopulateQueryMetrics = true,
                    });
            return await func(queryable).AsDocumentQuery().ExecuteNextAsync<TRes>();
        }
    await Query<Doc, string>("collection", "pk",
                (IOrderedQueryable<Doc> x) => x.SelectMany(p => p.Versions.SelectMany(d => d.UserGroups.SelectMany(k => k.Users.Select(u => u.Name)))));
