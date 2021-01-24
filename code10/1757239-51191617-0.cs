    using (var queryable = client.CreateDocumentQuery<Book>(
        collectionLink,
        new FeedOptions { MaxItemCount = 10 })
        .Where(b => b.Title == "War and Peace")
        .AsDocumentQuery())
    {
        while (queryable.HasMoreResults) 
        {
            foreach(Book b in await queryable.ExecuteNextAsync<Book>())
            {
                // Iterate through books
            }
        }
    }
