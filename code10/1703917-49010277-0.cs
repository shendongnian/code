    public static IQueryable<T> GetItemsQueryable<T>()
    {
        IQueryable<T> query = client.CreateDocumentQuery<T>(
            collection.SelfLink,
            new FeedOptions { MaxItemCount = -1 })
            .AsQueryable<T>();
        return query;
    }
