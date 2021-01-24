    public static void BulkDelete(IOrganizationService service, DataCollection<EntityReference> entityReferences)
       {
           // Create an ExecuteMultipleRequest object.
           var multipleRequest = new ExecuteMultipleRequest()
           {
               // Assign settings that define execution behavior: continue on error, return responses. 
               Settings = new ExecuteMultipleSettings()
               {
                   ContinueOnError = false,
                   ReturnResponses = true
               },
               // Create an empty organization request collection.
               Requests = new OrganizationRequestCollection()
           };
     
           // Add a DeleteRequest for each entity to the request collection.
           foreach (var entityRef in entityReferences)
           {
               DeleteRequest deleteRequest = new DeleteRequest { Target = entityRef };
               multipleRequest.Requests.Add(deleteRequest);
           }
     
           // Execute all the requests in the request collection using a single web method call.
           ExecuteMultipleResponse multipleResponse = (ExecuteMultipleResponse)service.Execute(multipleRequest);
       }
