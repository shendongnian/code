    public sealed class CosmosStoreSingleton<T>
    {
        private static ICosmosStore<T> instance = null;
    
        public static ICosmosStore<T> Instance
        {
            get
            {
                if (instance==null)
                {
                    var cosmosSettings = new CosmosStoreSettings("<<databaseName>>", "<<cosmosUri>>", "<<authkey>>");
                    instance = new CosmosStore<T>(cosmosSettings);
                }
    
                return instance;
            }
        }
    }
