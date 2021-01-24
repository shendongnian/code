            {
                client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
                var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
                Item queryItem = client.CreateDocumentQuery<Item>(uri , "select * from c")
                                                .AsEnumerable()
                                                .FirstOrDefault();
    
                Console.WriteLine("\nRead {0}", queryItem);
           }
    }
