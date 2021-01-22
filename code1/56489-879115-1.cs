    public IQueryable<TeamBE> ExcuteTeamQuery(IQueryable<Team> query, int loadLevel)
    {
        return 
            query.select<Team, TeamBE> (team => 
               new TeamBE
               {
                  TeamID = team.TeamID,
                  TeamMembers = (HaveToLoad(LoadLevel.TeamMembers, loadLevel)) ? team.TeamMembers : null 
               }
    }
  
    enter code here
