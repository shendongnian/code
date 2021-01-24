    public class Logger
        {
            //Storage credentials.
            public StorageCredentials credentials = null;
    
            //Storage account.
            public CloudStorageAccount account = null;
    
            //Table client
            public CloudTableClient tableClient = null;
    
            //Table.
            public CloudTable table = null;
    
            // Constructor.
            public Logger(string tableName, string accountName, string accountKey)
            {
                //Create storage credentials object.
                credentials = new StorageCredentials(accountName,
                accountKey);
    
                //Create storage account object.
                account = new CloudStorageAccount(credentials, false);
    
                //Create table client object.
                tableClient = account.CreateCloudTableClient();
    
                //Get the table reference.
                table = tableClient.GetTableReference(tableName);
    
                //Check whether table exist or not.
                if (!table.Exists())
                {
                    //Create the table if not exist.
                    table.Create();
                }
            }
    
            // Insert into table.
            public void Insert(AzureLog objAzureLog)
            {
                // Create the new insert table operation.
                TableOperation insertOperation = TableOperation.Insert(objAzureLog);
    
                // Execute the insert statement.
                table.Execute(insertOperation);
            }
        }
