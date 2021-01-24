    var multipleRequest = new Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest()
                    {
                        Settings = new ExecuteMultipleSettings()
                        {
                            ContinueOnError = false,
                            ReturnResponses = true
                        },
                        Requests = new OrganizationRequestCollection()
                    };
                    EntityCollection accounts = service.RetrieveMultiple(new FetchExpression(fetchquery));
                    foreach (var c in accounts.Entities)
                    {
    
                        Console.WriteLine("accountid: {0}", c.Attributes["name"]);                
                        Microsoft.Xrm.Sdk.Messages.UpdateRequest updateRequest = new Microsoft.Xrm.Sdk.Messages.UpdateRequest { Target = c };
                        multipleRequest.Requests.Add(updateRequest);
                        c.Attributes["name"] = "New Name";
                        
                    }
    Microsoft.Xrm.Sdk.Messages.ExecuteMultipleResponse multipleResponse = (Microsoft.Xrm.Sdk.Messages.ExecuteMultipleResponse)service.Execute(multipleRequest);
