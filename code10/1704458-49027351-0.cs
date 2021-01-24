    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace QueryLinkedWIQL
    {
        class Program
        {
            static void Main(string[] args)
            {
                int _id = 742;
                try
                {
                    TfsTeamProjectCollection _tpc = new TfsTeamProjectCollection(new Uri("http://myserver/DefaultCollection"));
                    WorkItemStore _wistore = _tpc.GetService<WorkItemStore>();
                    var _parents = GetParentsWithWIQL(_wistore, _id);
                    if (_parents.Count == 0)
                    {
                        Console.WriteLine("There is no parent for ID: " + _id);
                        return;
                    }
                    for (int i = 0; i < _parents.Count; i++)
                        Console.WriteLine("{0} parent: Team project '{1}', Type '{2}', Id '{3}', Title '{4}'",
                            (i == 0) ? "Main" : "Next", _parents[i].Project.Name, _parents[i].Type.Name, _parents[i].Id, _parents[i].Title);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
            private static List<WorkItem> GetParentsWithWIQL(WorkItemStore pWiStore, int pId)
            {
                List<WorkItem> _parents = new List<WorkItem>();
                string _wiql = String.Format("SELECT [System.Id] FROM WorkItemLinks WHERE ([Source].[System.WorkItemType] <> '') And ([System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward') And ([Target].[System.Id] = {0}) ORDER BY [System.Id] mode(Recursive,ReturnMatchingChildren)", pId);
                Query _query = new Query(pWiStore, _wiql);
                WorkItemLinkInfo[] _links = _query.RunLinkQuery();
                for (int i = 0; i < _links.Count(); i++)
                    if (_links[i].TargetId != pId) _parents.Add(pWiStore.GetWorkItem(_links[i].TargetId));
                return _parents;
            }
        }
    }
