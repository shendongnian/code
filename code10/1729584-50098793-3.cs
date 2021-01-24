    public static async Task StoreAuditDetail(AuditDetailResponse auditDetail, string endpointUrl, string authorizationKey)
        {
          using (var cosmosClient = new DocumentClient(new Uri(endpointUrl), authorizationKey))
          {
            const string db = "iauditor-database";
            const string collection = "audit-details";
            Uri databaseUri = UriFactory.CreateDatabaseUri(db);
            DocumentCollection graph = cosmosClient.CreateDocumentCollectionIfNotExistsAsync(
              databaseUri,
              new DocumentCollection { Id = collection },
              new RequestOptions { OfferThroughput = 400 }).Result;
    
            List<dynamic> q = cosmosClient.CreateGremlinQuery<dynamic>(graph,
                $"g.V().hasLabel('audit-details').values('id')"
                ).ExecuteNextAsync().Result.ToList();
            
            if (!q.Contains(auditDetail.audit_id))
            {
              try
              {
                await cosmosClient.CreateDocumentAsync(graph.DocumentsLink, new { label = "audit-details", id = auditDetail.audit_id, detail = auditDetail } );
              }
              catch (Exception ex)
              {
                throw;
              }
            }
          }
        }
