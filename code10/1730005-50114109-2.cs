    void SavePath(string fullpath)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                // Create the CloudTable object that represents the "people" table.
                CloudTable table = tableClient.GetTableReference("people");
    
                // Create a new customer entity.
                CustomerEntity customer1 = new CustomerEntity("joey", "cai");
                customer1.path = fullpath;
                
    
                // Create the TableOperation object that inserts the customer entity.
                TableOperation insertOperation = TableOperation.Insert(customer1);
    
                // Execute the insert operation.
                table.Execute(insertOperation);
            }
            public class CustomerEntity : TableEntity
            {
                public CustomerEntity(string lastName, string firstName)
                {
                    this.PartitionKey = lastName;
                    this.RowKey = firstName;
                }
    
                public CustomerEntity() { }
    
                public string path { get; set; }
                
            }
