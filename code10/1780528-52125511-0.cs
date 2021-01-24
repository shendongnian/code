     private static void GetWorkItemsTest()
            {
               //var creds = new VssCredentials();
               // creds.Storage = new VssClientCredentialStorage();
                VssCredentials c = new VssCredentials(new Microsoft.VisualStudio.Services.Common.VssBasicCredential(string.Empty, "{PAT}"));
                Uri url = new Uri("https://starain.visualstudio.com"); 
    
               var connection = new VssConnection(url, c);
               var wiClient = connection.GetClient<WorkItemTrackingHttpClient>();
                IEnumerable<int> ids = new List<int> { 851, 180 };
                var wis = wiClient.GetWorkItemsAsync(ids, null, null, WorkItemExpand.Relations).Result;
                foreach (WorkItem wi in wis)
                {
                    Console.WriteLine(wi.Id);
                    GetChildrenWIT(wiClient, wi, 1,new List<int> { wi.Id.Value});
                }
            }
            private static void GetChildrenWIT(WorkItemTrackingHttpClient witClient, WorkItem child, int width,List<int> existingWit)
            { 
                if (child.Relations != null)
                {
                    foreach (WorkItemRelation wir in child.Relations)
                    {
                        var indent = new string('-', width);
                        int id = int.Parse(wir.Url.Split('/').Last());
                        if(!existingWit.Contains(id))
                        {
                            Console.WriteLine(string.Format("{0}{1}", indent, wir.Rel));
                            var childwit = witClient.GetWorkItemAsync(id, null, null, WorkItemExpand.Relations).Result;
                            existingWit.Add(childwit.Id.Value);
                            Console.WriteLine(string.Format("{0}-{1}", indent, childwit.Id));
                            GetChildrenWIT(witClient, childwit, width+1, existingWit);
                        }         
                    }
                }
            }
