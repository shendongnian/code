    using System;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    
    namespace createNewWorkItem
    {
        class Program
        {
            static int Main(string[] args)
            {
                Uri collectionUri = new Uri("http://server:8080/TFS/");
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(collectionUri);
                WorkItemStore workItemStore = tpc.GetService<WorkItemStore>();
                Project teamProject = workItemStore.Projects["MyProject"];
                WorkItemType workItemType = teamProject.WorkItemTypes["Defect"];
    
                WorkItem Defect = new WorkItem(workItemType);
    
                Defect.Title = "TITLE GOES HERE";
                Defect.Description = "DESCRIPTION GOES HERE";
                Defect.Fields["Issue ID"].Value = "999999";
    
    
                Defect.Save();
                return (Defect.Id);
    
            }
        }
    }
