    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Microsoft.VisualStudio.Services.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace DownloadWITAttachments
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("https://{account}.visualstudio.com");
                string PAT = "xxxxx personal access token";
                string project = "Project Name";
    
                VssBasicCredential credentials = new VssBasicCredential("", PAT);
    
                //create a wiql object and build our query
                Wiql wiql = new Wiql()
                {
                    Query = "Select * " +
                            "From WorkItems " +
                            "Where [Work Item Type] = 'Task' " +
                            "And [System.TeamProject] = '" + project + "' " +
                            "And [System.State] <> 'Closed' " +
                            "Order By [State] Asc, [Changed Date] Desc"
                };
    
                //create instance of work item tracking http client
                using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
                {
                    //execute the query to get the list of work items in the results
                    WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;
    
                    //some error handling                
                    if (workItemQueryResult.WorkItems.Count() != 0)
                    {
                        //need to get the list of our work item ids and put them into an array
                        List<int> list = new List<int>();
                        foreach (var item in workItemQueryResult.WorkItems)
                        {
                            list.Add(item.Id);
                        }
                        int[] arr = list.ToArray();
    
                        //build a list of the fields we want to see
                        string[] fields = new string[3];
                        fields[0] = "System.Id";
                        fields[1] = "System.Title";
                        fields[2] = "System.State";
    
                        //get work items for the ids found in query
                        var workItems = workItemTrackingHttpClient.GetWorkItemsAsync(arr, fields, workItemQueryResult.AsOf).Result;
    
                        Console.WriteLine("Query Results: {0} items found", workItems.Count);
    
                        //loop though work items and write to console
                        foreach (var workItem in workItems)
                        {
                            Console.WriteLine("ID:{0} Title:{1}  State:{2}", workItem.Id, workItem.Fields["System.Title"], workItem.Fields["System.State"]);
                        }
    
                        Console.ReadLine();
                    }
                }
            }
        }
    }
