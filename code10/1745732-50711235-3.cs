        public static List<T> QueryAllDocument(string Uri, string Key, string DatabaseName, string CollectionName)
        {
            DocumentClient client = new DocumentClient(new Uri(Uri), Key, new ConnectionPolicy { EnableEndpointDiscovery = false });
            List<T> list = client.CreateDocumentQuery<T>(UriFactory.CreateDocumentCollectionUri(DatabaseName, CollectionName).ToString(), new SqlQuerySpec("SELECT * FROM c"), new FeedOptions { MaxItemCount = -1 }).ToList<T>();
            return list;
        }
