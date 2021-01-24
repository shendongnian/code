    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Proxy;
    using System;
    using System.IO;
    
    namespace VSTS_DownloadWITAttachment
    {
        class Program
        {
            static void Main(string[] args)
            {
                TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri("https://account.visualstudio.com/"));
                ttpc.EnsureAuthenticated();
                WorkItemStore wistore = ttpc.GetService<WorkItemStore>();
                WorkItem wi = wistore.GetWorkItem(94);
                WorkItemServer wiserver = ttpc.GetService<WorkItemServer>();
                string tmppath = wiserver.DownloadFile(wi.Attachments[0].Id);
                string filename = string.Format("D:\\WITAttachments\\{0}-{1}", wi.Fields["ID"].Value, wi.Attachments[0].Name);
                File.Copy(tmppath, filename);
            }
        }
    }
