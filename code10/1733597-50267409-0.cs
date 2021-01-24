    // Add table entity class in JobA Program class and JobB Functions class
    class MyEntity : TableEntity
    {
        public DateTime ExecutionTime { get; set; }
    }
    //In JobA, achieve what you would like to do 
     var accountId = account.AccountId;
     CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
     CloudTable table = tableClient.GetTableReference("execution");
     table.CreateIfNotExists();
     // table entity use combination of partionkey and rowkey as entity identifier, so I set both of them to accountId
     TableOperation retriveOperation = TableOperation.Retrieve<MyEntity>(accountId, accountId);
     MyEntity retriveEntity = (MyEntity)table.Execute(retriveOperation).Result;
     if (retriveEntity != null)
     {
         if (retriveEntity.ExecutionTime> DateTime.UtcNow.AddMinutes(-60))
         {
             CloudQueueMessage message = new CloudQueueMessage(accountId);
             queue.AddMessage(message);
         }
     }else
     {
         CloudQueueMessage message = new CloudQueueMessage(accountId);
         queue.AddMessage(message);
     }
     
     //In JobB, add operations to store execution time after business logic 
     //Connection operations omitted, please add by yourself.
     CloudTable table = tableClient.GetTableReference("execution");
     table.CreateIfNotExists();
     TableOperation retriveOperation = TableOperation.Retrieve<MyEntity>(accountId, accountId);
     MyEntity retriveEntity = (MyEntity)table.Execute(retriveOperation).Result;
     if (retriveEntity != null)
     {
          retriveEntity.ExecutionTime = DateTime.UtcNow;
          TableOperation updateOperation = TableOperation.Replace(retriveEntity);
          table.Execute(updateOperation);
     }
     else
     {
          retriveEntity = new MyEntity
          {
               ExecutionTime = DateTime.UtcNow,
               PartitionKey = accountId,
               RowKey = accountId
           };
          TableOperation insertOperation = TableOperation.Insert(retriveEntity);
          table.Execute(insertOperation);
     }
