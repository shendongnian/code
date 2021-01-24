    using JayGongDocumentDB.pojo;
    using Microsoft.Azure.Documents;
    using Microsoft.Azure.Documents.Client;
    using Microsoft.Azure.Documents.Linq;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace JayGongDocumentDB.module
    {
        class TestTrigger
        {
            private static readonly string endpointUrl = "https://***.documents.azure.com:443/";
            private static readonly string authorizationKey = "***";
            private static readonly string databaseId = "db";
            private static readonly string collectionId = "coll";
    
            private static DocumentClient client;
    
            public static async Task TestTriggerAsync()
    
            {
                client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
                var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);
                var doc = new Document
                {
                    Id = "My Document 1",
                    //OrderNumber - calculated by PreTrigger
                };
    
                var result = await client.CreateDocumentAsync("dbs/db/colls/coll", doc,
                            new RequestOptions { PreTriggerInclude = new List<string> { "calculate" } });
    
                Console.WriteLine(result.Resource.GetPropertyValue<String>("OrderNumber"));
            }
        }
    }
