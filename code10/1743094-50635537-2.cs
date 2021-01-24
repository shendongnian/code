        public static void CreateCosmosDocument()
        {
            DocumentClient client = new DocumentClient(new Uri("https://xxxxx/"), "C2y6yDjf5/R+ob0N8A7Cgv30VRDJxxxxM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", new ConnectionPolicy { EnableEndpointDiscovery = false });
           
            TestEntity testEntity = new TestEntity { x = 11, y = 11, name = "wakaka", dynam = "hello dynam" };
            var createdItem = client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), new NotificationDetails { DateCreated=DateTime.Now, DateSent=DateTime.Now, TemplateUrl="www.baidu.com", Model= testEntity });                     
        }
