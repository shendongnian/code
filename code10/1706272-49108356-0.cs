    using Microsoft.TeamFoundation.Client;
    using Microsoft.TeamFoundation.Framework.Common;
    using Microsoft.TeamFoundation.ProcessConfiguration.Client;
    using Microsoft.TeamFoundation.WorkItemTracking.Client;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace QueryLinkedWIQL
    {
        class Program
        {
            static List<TeamFoundationTeam> ListTeams(TfsTeamProjectCollection pTpc, Project pProject)
            {
                TfsTeamService _teamService = pTpc.GetService<TfsTeamService>();
                var _teams = _teamService.QueryTeams(pProject.Uri.ToString());
                return (from t in _teams select t).ToList();
            }
            static bool GetTeamsSettings(TfsTeamProjectCollection pTpc, TeamFoundationTeam pTeam)
            {
                try
                {
                    var _teamConfig = pTpc.GetService<TeamSettingsConfigurationService>();
                    var _configs = _teamConfig.GetTeamConfigurations(new Guid[] { pTeam.Identity.TeamFoundationId  });
                    Console.WriteLine("============={0}==================", pTeam.Name);
                    Console.WriteLine("Team Members: ");
                    foreach (var _member in pTeam.GetMembers(pTpc, MembershipQuery.Expanded))
                        Console.WriteLine("Display Name: " + _member.DisplayName + " || Is active: " + _member.IsActive);
                    foreach( var _config in _configs)
                    {
                        Console.WriteLine("Team current iteration: " + _config.TeamSettings.CurrentIterationPath);
                        Console.WriteLine("Team selected iterations:");
                        foreach (var _iteration in _config.TeamSettings.IterationPaths)
                            Console.WriteLine(_iteration);
                        Console.WriteLine("Team selected areas:");
                        foreach (var _area in _config.TeamSettings.TeamFieldValues)
                            Console.WriteLine("Area path: " + _area.Value + " || Include children: " + _area.IncludeChildren.ToString());
                    }
                    Console.WriteLine("===============================");
                }
                catch (Exception)
                {
                    return false;
                }
                return true;
            }
            static void Main(string[] args)
            {
                string _teamProject = "YourProjectName";
                try
                {
                    TfsTeamProjectCollection _tpc = new TfsTeamProjectCollection(new Uri("http://yourserver/DefaultCollection"));
                    WorkItemStore _wistore = _tpc.GetService<WorkItemStore>();
                    var _teams = ListTeams(_tpc, _wistore.Projects[_teamProject]);
                    foreach (var _team in _teams) GetTeamsSettings(_tpc, _team);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
            }
        }
    }
