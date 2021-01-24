    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System;
    using System.Collections.Generic;
    
    namespace GetWorkItemList
    {
        class Program
        {
            static void Main(string[] args)
            {
                
                string info = String.Empty;
                NetworkCredential netCred = new NetworkCredential("xxx@outlook.com", "password");      
                var tpc = new TfsTeamProjectCollection(new Uri("https://xxxx.visualstudio.com"), netCred);
    
                WorkItemStore workItemStore = new WorkItemStore(tpc);
    
                Query query = new Query(workItemStore, "SELECT * FROM WorkItems WHERE [System.TeamProject] = @project", new Dictionary<string, string>() { { "project", "ProjectNameHere" } });
    
                WorkItemCollection wic = query.RunQuery();
    
                foreach (WorkItem item in wic)
                {
                    info += String.Format("WIT:{0} ID: {1}  Title: {2}\n", item.Type.Name, item.Id, item.Title);
                }
    
                Console.WriteLine(info);
                Console.ReadLine();
            }
        }
    }  
