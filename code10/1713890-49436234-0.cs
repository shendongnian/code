        using Microsoft.TeamFoundation.Client;
        using Microsoft.TeamFoundation.Framework.Client;
        using Microsoft.TeamFoundation.Framework.Common;
        using Microsoft.TeamFoundation.Server;
        using Microsoft.TeamFoundation.WorkItemTracking.Client;
        using System;
        using System.Collections.Generic;
        namespace GetUserіAndItearions
        {
            class Program
            {
                public class Iteration
                {
                    public string Path;
                    public DateTime DateFrom;
                    public DateTime DateTo;
                }
                static void Main(string[] args)
                {
                    string _teamProject = "Your_Project_Name";
                    try
                    {
                        TfsTeamProjectCollection _tpc = new TfsTeamProjectCollection(new Uri("http://your_server:8080/tfs/DefaultCollection"));
                        GetAllUsers(_tpc, _teamProject);
                        GetAllIterations(_tpc, _teamProject);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
                private static void GetAllIterations(TfsTeamProjectCollection pTpc, string pProjectName)
                {
                    List<Iteration> _its = new List<Iteration>();
                    WorkItemStore _wistore = pTpc.GetService<WorkItemStore>();
                    var _css = pTpc.GetService<ICommonStructureService4>();
           
                    foreach (Node _node in _wistore.Projects[pProjectName].IterationRootNodes)
                        FillIterations(_css, _node, _its);
                    Console.WriteLine("Iterations:");
                    foreach (Iteration _it in _its) Console.WriteLine("{0}:{1}-{2}", _it.Path, 
                        (_it.DateFrom == DateTime.MinValue) ? "0" : _it.DateFrom.ToShortDateString(), (_it.DateTo== DateTime.MinValue) ? "0" : _it.DateTo.ToShortDateString());
                }
                private static void FillIterations(ICommonStructureService4 pCss, Node pNode, List<Iteration> pIts)
                {
                    var _nodeInfo = pCss.GetNode(pNode.Uri.AbsoluteUri);
                    pIts.Add(new Iteration { Path = _nodeInfo.Path,
                        DateFrom = (_nodeInfo.StartDate == null) ? DateTime.MinValue : (DateTime)_nodeInfo.StartDate,
                        DateTo = (_nodeInfo.FinishDate == null) ? DateTime.MinValue : (DateTime)_nodeInfo.FinishDate });
                    if (pNode.HasChildNodes)
                        foreach (Node _node in pNode.ChildNodes)
                            FillIterations(pCss, _node, pIts);
                }
                private static void GetAllUsers(TfsTeamProjectCollection pTpc, string pProjectName)
                {
                    List<string> listUsers = new List<string>();
                    WorkItemStore _wistore = pTpc.GetService<WorkItemStore>();
                    var _gss = pTpc.GetService<IIdentityManagementService>();
                    var _teamProject = _wistore.Projects[pProjectName];
                    string _validGroupName = "[" + pProjectName + "]\\Project Valid Users";
                    TeamFoundationIdentity _group = _gss.ReadIdentity(IdentitySearchFactor.DisplayName, _validGroupName, MembershipQuery.Expanded, ReadIdentityOptions.ExtendedProperties);
                    List<string> _memebersIds = new List<string>();
                    foreach (var _member in _group.Members) _memebersIds.Add(_member.Identifier);
                
                    var _members = _gss.ReadIdentities(IdentitySearchFactor.Identifier, _memebersIds.ToArray(), MembershipQuery.Expanded, ReadIdentityOptions.ExtendedProperties);
                    foreach (var _member in _members) if (!_member[0].IsContainer) listUsers.Add(_member[0].DisplayName);
                    Console.WriteLine("Users:");
                    foreach (var _user in listUsers) Console.WriteLine("{0}", _user);
                }
            }
        }
