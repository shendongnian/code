    class Program
        {
            static void Main(string[] args)
            {
                // Parse the connection string and return a reference to the storage account.
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
    
                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                // Retrieve a reference to the table.
                CloudTable table = tableClient.GetTableReference("Mytable");
    
                // Create the table if it doesn't exist.
                table.CreateIfNotExists();
    
                // Create a new customer entity.
                CustomerEntity customer1 = new CustomerEntity("Harp", "Walter");
                customer1.Email = "Walter@contoso.com";
                customer1.PhoneNumber = "425-555-0101";
    
                // Create the TableOperation object that inserts the customer entity.
                TableOperation insertOperation = TableOperation.Insert(customer1);
    
                // Execute the insert operation.
                table.Execute(insertOperation);
            }
        }
