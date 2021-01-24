    public class CosmosDbRepo : ICosmosDbRepo
    {
       private static DocumentClient _cosmosDocumentClient; 
       public CosmosDbRepo(IDatabaseFactory databaseFactory, CosmosDbConnectionParameters cosmosDbConnectionParameters)
        {           
            _collectionUri = UriFactory.CreateDocumentCollectionUri(cosmosDbConnectionParameters.DatabaseId, cosmosDbConnectionParameters.CollectionId);
            if (_cosmosWriteDocumentClient == null)
            {
                _cosmosDocumentClient = databaseFactory.CreateDbConnection(cosmosDbConnectionParameters, ConnectionMode.Direct).DocumentClient;
            }
        }
    }
