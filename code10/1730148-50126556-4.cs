    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Proxy;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi;
    using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
    using Microsoft.VisualStudio.Services.Common;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    
    namespace DownloadWITAttachments
    {
        class Program
        {
            static void Main(string[] args)
            {
                Uri uri = new Uri("https://account.visualstudio.com");
                string PAT = "xxxxxxxxxxxx";
                string project = "ProjectName";
    
                VssBasicCredential credentials = new VssBasicCredential("", PAT);
    
                //create a wiql object and build our query
                Wiql wiql = new Wiql()
                {
                    Query = "Select * " +
                            "From WorkItems " +
                            "Where [Work Item Type] = 'User Story' " +
                            "And [System.TeamProject] = '" + project + "' " +
                            "And [System.State] <> 'Closed' " +
                            "And [System.AttachedFileCount] > 0 " +
                            "Order By [State] Asc, [Changed Date] Desc"
                };
    
                //create instance of work item tracking http client
                using (WorkItemTrackingHttpClient workItemTrackingHttpClient = new WorkItemTrackingHttpClient(uri, credentials))
                {
                    //execute the query to get the list of work items in the results
                    WorkItemQueryResult workItemQueryResult = workItemTrackingHttpClient.QueryByWiqlAsync(wiql).Result;
                   
                    if (workItemQueryResult.WorkItems.Count() != 0)
                    {
                        //Download the first attachment for each work item.
                        foreach (var item in workItemQueryResult.WorkItems)
                        {
                            TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(uri);
                            ttpc.EnsureAuthenticated();
                            WorkItemStore wistore = ttpc.GetService<WorkItemStore>();
                            Microsoft.TeamFoundation.WorkItemTracking.Client.WorkItem wi = wistore.GetWorkItem(item.Id);
                            WorkItemServer wiserver = ttpc.GetService<WorkItemServer>();                       
                            string tmppath = wiserver.DownloadFile(wi.Attachments[0].Id);
                            string filename = string.Format("D:\\temp\\vsts\\{0}-{1}", wi.Fields["ID"].Value, wi.Attachments[0].Name);
                            File.Copy(tmppath, filename);
                        }
                    }
                }
            }
        }
    }
