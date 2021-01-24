    public static T TakeOne<T>(this IQueryable<T> source)
    {
        var documentQuery = source.AsDocumentQuery();            
        if (documentQuery.HasMoreResults)
        {
            var queryResult = documentQuery.ExecuteNextAsync<T>().Result;
            if (queryResult.Any())
            {
                return queryResult.Single<T>();
            }
        }
        return default(T);
    }
