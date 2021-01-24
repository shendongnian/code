        public static List<TestEntity> QueryAllDocument()
        {
            Microsoft.Azure.Documents.Client.DocumentClient client = new DocumentClient(new Uri("https://localhost:8081/"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", new ConnectionPolicy { EnableEndpointDiscovery = false });
            List<TestEntity> list = client.CreateDocumentQuery<TestEntity>(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items").ToString(), new SqlQuerySpec("SELECT * FROM c"), new FeedOptions { MaxItemCount = -1 }).ToList<TestEntity>();
            return list;
        }
