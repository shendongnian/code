    using System;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.VisualStudio.Services.WebApi;
    using Microsoft.VisualStudio.Services.WebApi.Patch.Json;
    using Microsoft.VisualStudio.Services.WebApi.Patch;
    
    namespace UpdateFieldValue
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myCredentials = new VssClientCredentials();
                var connection = new VssConnection(new Uri(@"http://server:8080/tfs/DefaultCollection"), myCredentials);
                WorkItemTrackingHttpClient workItemTrackingClient = connection.GetClient<WorkItemTrackingHttpClient>();
                int workitemid = 112;
                JsonPatchDocument patchDocument = new JsonPatchDocument();
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Test,
                        Path = "/rev",
                        Value = "6"
                    }
                );
    
                patchDocument.Add(
                    new JsonPatchOperation()
                    {
                        Operation = Operation.Add,
                        Path = "/fields/System.AssignedTo",
                        Value = "Domain\\user"
                    }
                );
    
                Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models.WorkItem result = workItemTrackingClient.UpdateWorkItemAsync(patchDocument, workitemid).Result;
    
            }
        }
    } 
