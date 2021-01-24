      CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
      CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
      CloudTable table = tableClient.GetTableReference("humans");
                
      var condition = TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition("PartitionKey",QueryComparisons.Equal, "Harp222"),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition("RowKey",QueryComparisons.Equal, "Walter222")
                    );
    
       var query =new TableQuery<CustomerEntity>().Where(condition);
    
       foreach (CustomerEntity entity in table.ExecuteQuery(query))
       {
          Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                            entity.Email, entity.PhoneNumber);
       }
