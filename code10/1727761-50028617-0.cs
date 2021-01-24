        // Set up default team sprint date and time
        var teamConfig = _tfs.GetService<TeamSettingsConfigurationService>();
        var css = _tfs.GetService<ICommonStructureService4>();
        string rootNodePath = string.Format("\\{0}\\Iteration\\Release 1\\Sprint 1", _selectedTeamProject.Name);
        var pathRoot = css.GetNodeFromPath(rootNodePath);
        css.SetIterationDates(pathRoot.Uri, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(7));
        var configs = teamConfig.GetTeamConfigurationsForUser(new[] { _selectedTeamProject.Uri });
        var team = configs.Where(c => c.TeamName == "Demo").FirstOrDefault();
        var ts = team.TeamSettings;
        ts.BacklogIterationPath = string.Format(@"{0}\Release 1", _selectedTeamProject.Name);
        ts.IterationPaths = new string[] { string.Format(@"{0}\Release 1\Sprint 1", _selectedTeamProject.Name), string.Format(@"{0}\Release 1\Sprint 2", _selectedTeamProject.Name) };
        var tfv = new TeamFieldValue();
        tfv.IncludeChildren = true;
        tfv.Value = _selectedTeamProject.Name;
        ts.TeamFieldValues = new []{tfv};
        teamConfig.SetTeamSettings(team.TeamId, ts);
