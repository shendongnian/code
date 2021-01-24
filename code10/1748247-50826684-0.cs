    using System.Threading.Tasks;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    
    namespace CosmosDBTableApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string ConnectionString = "{CosmosDB/Table Connection String}";
                const string TableName = "{Table Name}";
                CreateTableIfNotExists(ConnectionString, TableName).Wait();
            }
    
            private static async Task CreateTableIfNotExists(string connectionString, string tableName)
            {
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
                CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
                CloudTable table = tableClient.GetTableReference(tableName);
                await table.CreateIfNotExistsAsync();
            }
        }
    }
