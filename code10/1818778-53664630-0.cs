    static void Main(string[] args)
        {
    
            //CloudTable table = CreateTableAsync("j").Result;
            //var result = QueryTableAsync("test").Result;
            TableQuerySegment <ResponseEntity>  resultE=  QueryTableAsync("test").Result;
            foreach(ResponseEntity re in resultE)
            {
                Console.WriteLine("Timestamp:   "+re.Timestamp);
                Console.WriteLine("------------------------------------------");
            }
            Console.WriteLine("execute done");
    
            Console.ReadLine();
       
    } 
    public static async Task<TableQuerySegment<ResponseEntity>> QueryTableAsync(string tableName)
            {
                string cst = "DefaultEndpointsProtocol=https;AccountName=***;AccountKey=***;TableEndpoint=https://***.table.cosmosdb.azure.com:443/;";
                CloudStorageAccount storageAccount = CreateStorageAccountFromConnectionString(cst);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tableName);
        
                var filter = TableQuery.GenerateFilterConditionForDate(
                    "Timestamp",
                    QueryComparisons.GreaterThanOrEqual,
                    DateTimeOffset.Now.AddDays(-10).Date);
        
                Console.WriteLine(filter);
        
                var query = new TableQuery<ResponseEntity>();
        
                var result = await table.ExecuteQuerySegmentedAsync(query, null);
        
                return result;
        
        }
