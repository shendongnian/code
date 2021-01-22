        public List<TeamBE> GetTeamsBySolutionID(int solutionID)
        {
            return GetTeamsBy(_GetTeamsBySolutionID(solutionID));
        }
        IQueryable<Team> _GetTeamsBySolutionID(int solutionID)
        {
            return from teamsTable in db.Teams
                   where teamsTable.SolutionID == SolutionID
                   select teamsTable;
        }
        List<TeamBE> GetTeamsBy(IQueryable<Team> teams)
        {
            List<TeamBE> teams = new List<TeamBE>();
            Esadmin db = new Esadmin(_connectionString);
            var qry = (from teamsTable in teams
                       join solutionsTable in db.Solutions on teamsTable.SolutionID equals solutionsTable.SolutionID
                       select new { teamsTable, solutionsTable.SolutionName });
            foreach (var result in qry)
            {
                TeamBE team = new TeamBE();
                team.TeamID = result.teamsTable.TeamID;
                team.Description = result.teamsTable.Description;
                team.Status = result.teamsTable.Status;
                team.LastModified = result.teamsTable.LastModified;
                team.SolutionID = result.teamsTable.SolutionID;
                team.SolutionName = result.SolutionName;
                team.Name = result.teamsTable.Name;
                team.LocationLevel = result.teamsTable.LocationLevel;
                team.AORDriven = result.teamsTable.AoRDriven;
                team.CriteriaID = result.teamsTable.CriteriaID ?? Guid.Empty;
                teams.Add(team);
            }
            return teams;
        }
