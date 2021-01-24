    CloudTableClient tableClient = new CloudTableClient("YOUR CONNECTION STRING");
    TableContinuationToken continuationToken = null;
    var allTables = new List<CloudTable>();
    do
    {
      var listingResult = await tableClient.ListTablesSegmentedAsync(continuationToken);
      var tables = listingResult.Result.ToList();
      var continuationToken = listingResult.ContinuationToken;
      //Add the tables to your allTables
    }
    while (continuationToken != null);
