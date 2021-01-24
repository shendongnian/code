    private static async Task ExecuteGremlinQueryAsync(DocumentClient client, DocumentCollection graph, string gremlinCommand)
            {
                IDocumentQuery<dynamic> query = client.CreateGremlinQuery<dynamic>(graph, gremlinCommand);
                while (query.HasMoreResults)
                {
                    foreach (dynamic result in await query.ExecuteNextAsync())
                    {
                        Console.WriteLine($"\t {JsonConvert.SerializeObject(result)}");
                    }
                }
    
            }
