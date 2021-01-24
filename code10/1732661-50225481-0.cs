    public static void  Main(string[] args)
            {
                method().Wait();
            }
            static private async Task method()
            {
                var connectionString = "DefaultEndpointsProtocol=https;AccountName=accountname;AccountKey=xFWWad+YMoW/R7P54ppqGMDs7obGYj3ciEjokt+nkomwYfOh6mUcmcvJLV/puGistsKuGCfOwreCfptK1AwAAQ==;EndpointSuffix=core.windows.net";
    
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    
                CloudTable table = tableClient.GetTableReference("table1");
    
                Person customer1 = new Person("Harp", "Walter");
                customer1.Firstname = "Walter@contoso.com";
                TableOperation insertOperation = TableOperation.Insert(customer1);
    
                await table.ExecuteAsync(insertOperation);
            }
            class Person : TableEntity
            {
                public Person(string lastName, string firstName)
                {
                    this.PartitionKey = lastName;
                    this.RowKey = firstName;
                }
    
                public Person() { }
    
                public string Firstname { get; set; }
            }
