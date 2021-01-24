    using System;
    using Microsoft.VisualStudio.Services.Client;
    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Proxy;
    using System.IO;
    
    namespace RetrieveAttachments
    {
        class Program
        {
            static void Main(string[] args)
            {
                var u = new Uri("http://172.17.16.163:8080/tfs/DefaultCollection");
                var c = new VssClientCredentials();
                int SharedStepsID = 748;
                TfsTeamProjectCollection tpc = new TfsTeamProjectCollection(u, c);
                tpc.EnsureAuthenticated();
                WorkItemStore wistore = tpc.GetService<WorkItemStore>();
                WorkItem wi = wistore.GetWorkItem(SharedStepsID);
                WorkItemServer wiserver = tpc.GetService<WorkItemServer>();
                int atc = wi.Attachments.Count;
     
                    for (int i = 0; i < atc; i++)
                    {
                        string tmppath = wiserver.DownloadFile(wi.Attachments[i].Id);
                        string filename = string.Format("D:\\temp\\vsts\\{0}-{1}", wi.Fields["ID"].Value, wi.Attachments[i].Name);
                        File.Copy(tmppath, filename);
                        Console.WriteLine(string.Format("{0}\n", filename));
                   }      
                Console.ReadLine();
            }
        }
    }
