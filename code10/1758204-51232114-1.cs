    public static class CosmosStoreFactory 
    {
        private static CosmosStoreSettings _settings = new CosmosStoreSettings("<<databaseName>>", "<<cosmosUri>>", "<<authkey>>");
        public static ICosmosStore<T> CreateForEntity<T>() where T: class
        {
             return new CosmosStore<T>(_settings);
        }
    }
