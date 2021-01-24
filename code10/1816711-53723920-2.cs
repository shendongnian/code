    var collection = new DocumentCollection
    {
        Id = "Customers", // just an example collection
    };
    
    // Set partition key
    collection.PartitionKey.Paths.Add("/CountryId"); // just an example of the partition key path
    
    // Set throughput
    var options = new RequestOptions
    {
        OfferThroughput = 400, // Default value is 10000. Currently set to minimum value to keep costs low.
    };
    
    // Create
    await client.CreateDocumentCollectionIfNotExistsAsync(
       UriFactory.CreateDatabaseUri("YourCosomosDatabaseId"),
       collection,
       options);
