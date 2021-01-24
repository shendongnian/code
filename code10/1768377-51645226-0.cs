    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System;
    using System.Linq;
    
    namespace AssociateWorkitems
    {
        class Program
        {
            static void Main(string[] args)
            {
                int UserStoryID = 53;
                int TestCaseID = 54;
    
                TfsTeamProjectCollection tfs;
                tfs = TfsTeamProjectCollectionFactory.GetTeamProjectCollection(new Uri("http://ictfs2015:8080/tfs/DefaultCollection")); 
                tfs.Authenticate();
    
                var workItemStore = new WorkItemStore(tfs);
                WorkItem wit = workItemStore.GetWorkItem(UserStoryID);
    
                //Set "Tested By" as the link type
                var linkTypes = workItemStore.WorkItemLinkTypes;
                WorkItemLinkType testedBy = linkTypes.FirstOrDefault(lt => lt.ForwardEnd.Name == "Tested By");
                WorkItemLinkTypeEnd linkTypeEnd = testedBy.ForwardEnd;
    
                //Add the link as related link.
                try
                {
                    wit.Links.Add(new RelatedLink(linkTypeEnd, TestCaseID));
                    wit.Save();
                    Console.WriteLine(string.Format("Linked TestCase {0} to UserStory {1}", TestCaseID, UserStoryID));
                }
                catch (Exception ex)
                {
                    // ignore "duplicate link" errors
                    if (!ex.Message.StartsWith("TF26181"))
                        Console.WriteLine("ex: " + ex.Message);
                }
                Console.ReadLine();
            }
        }
    }
