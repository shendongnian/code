     TableOperation to = TableOperation.Retrieve<Item>("PK","RK");
     TableResult tr = table.ExecuteAync(to).Result;
     var item;
     if (tr != null)
     {
         item = new Item
         {
             PartitionKey = "PARTITIONID",
             RowKey = "ROWID",                
             Name = "DEMO",  
         }
     }
     else
     {
         item = new Item
         {
             PartitionKey = "PARTITIONID",
             RowKey = "ROWID",                
             Name = "DEMO",  
             Email = "test@example.com",
             Address = "Britain"
         }
     }
     to = TableOperation.InsertOrMerge(item);
     tr = await ct.ExecuteAysnc(to).Result;
