        public static void CreateCosmosDocument()
        {
            DocumentClient client = new DocumentClient(new Uri("https://xxxxxx/"), "C2y6yDjf5/R+oxxxxxxx5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", new ConnectionPolicy { EnableEndpointDiscovery = false });
  
            var createdItem = client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri("ToDoList", "Items"), new NotificationDetails { DateCreated=DateTime.Now, DateSent=DateTime.Now, TemplateUrl="www.baidu.com", Model="dfdd" });
                       
        }
