    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
        namespace EngineTFSAutomation
        {
            class TFSHelper
            {
                static public WorkItemCollection QueryWorkItems(string server, string projectname)
                {
                    TeamFoundationServer tfs = TeamFoundationServerFactory.GetServer(server);
                    WorkItemStore workItemStore = (WorkItemStore)tfs.GetService(typeof(WorkItemStore));
                    Project p = workItemStore.Projects[projectname];
                    string wiqlQuery = "Select * from Issue where [System.TeamProject] = '"+projectname+"'";
                    wiqlQuery += " and [System.State] <> 'Deleted'";
                    wiqlQuery+= " order by ID";
                    WorkItemCollection witCollection = workItemStore.Query(wiqlQuery);
                    return witCollection;
                }
            }
        }
