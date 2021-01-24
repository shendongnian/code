    TfsTeamProjectCollection ttpc = new TfsTeamProjectCollection(new Uri("tfsuri"));
    TfsTeamService teamService = ttpc.GetService<TfsTeamService>();
    ICommonStructureService icss = ttpc.GetService<ICommonStructureService>();
    ProjectInfo projectInfo = icss.GetProjectFromName("ProjectName");
    var newteam = teamService.CreateTeam(projectInfo.Uri, "TeamName", null, null);
    TeamSettingsConfigurationService tscs = ttpc.GetService<TeamSettingsConfigurationService>();
    IEnumerable<Guid> teamsid = new Guid[] {newteam.Identity.TeamFoundationId };
    var teamsconfig = tscs.GetTeamConfigurations(teamsid);
    TeamConfiguration tc = teamsconfig.First();
    TeamFieldValue tfv = new TeamFieldValue();
    tfv.IncludeChildren = true;
    tfv.Value = "AreaPath";
    tc.TeamSettings.TeamFieldValues = new TeamFieldValue[] {tfv};
    tc.TeamSettings.BacklogIterationPath = "IterationPath";
    tscs.SetTeamSettings(tc.TeamId,tc.TeamSettings);  
       
