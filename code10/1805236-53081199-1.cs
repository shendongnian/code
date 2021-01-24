        public interface ITableStorageAccount { string Method(); }
        public class TableStorageAccount : ITableStorageAccount
        {
        
            private readonly IConfiguration Configuration;
            public TableStorageAccount(IConfiguration configuration)
            {
                Configuration = configuration;
            }
        
            // an example return table storage uri
            public string Method()
            {
                string cre = Configuration["SASToken"];
                CloudTableClient table = new CloudTableClient(new Uri("xxx"), new StorageCredentials(cre));
                return table.BaseUri.AbsolutePath;
            }
        }
