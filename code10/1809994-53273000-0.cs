            static void Main(string[] args)
            {
                CloudStorageAccount storageAccount = new CloudStorageAccount(new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials("your_account", "your_key"),true);
    
                // Create the table client.
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                // Create the CloudTable object that represents the "people" table.
                CloudTable table = tableClient.GetTableReference("people");
    
                string myQuery = string.Empty;
                
                List<string> myConditionLists = new List<string>();
                myConditionLists.Add("Ben1");
                myConditionLists.Add("Ben2");
                myConditionLists.Add("Ben3");
                myConditionLists.Add("Ben4");
                myConditionLists.Add("Ben5");
    
                
                int i = 0;
                
                foreach (string myCondition in myConditionLists)
                {
                    i++;
                    //if i == 1, specify the myQuery to an non-empty query string.
                    if (i == 1) { myQuery = TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.NotEqual, myCondition); }
                    else
                    {
                        myQuery = TableQuery.CombineFilters(
                            myQuery,
                            TableOperators.And,
                            TableQuery.GenerateFilterCondition("RowKey", QueryComparisons.NotEqual, myCondition)
                            );
                    }
                }
    
                TableQuery<CustomerEntity> query = new TableQuery<CustomerEntity>().Where(myQuery);
    
                foreach (CustomerEntity entity in table.ExecuteQuery(query))
                {
                    Console.WriteLine("{0}, {1}\t{2}\t{3}", entity.PartitionKey, entity.RowKey,
                        entity.Email, entity.PhoneNumber);
                }
    
    
                Console.WriteLine("---completed---");
                Console.ReadLine();
            }
