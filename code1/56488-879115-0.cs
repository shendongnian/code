    //This returns an IQueryable of your Linq2Sql entities, here you put your query.
    protected IQueryable<Team> GetTeamByIdQuery(Guid teamID)
    {
        var qry = (from TeamsTable in db.Teams
                   where blablabla.....
                   select Teams;
        return qry;
    }
    //This will return your real entity
    public IList<TeamBE> GetTeamById(Guid teamID)
    {
        var query = this.GetTeamByIdQuery(teamID);
        IList<TeamBE> teams = ExecuteTeamQuery(query).toList<TeamBE>();
        return teams;
    }
    //this method will do the mapping from your L2S entities to your model entities
    protected IQueryable<TeamBE> ExcuteTeamQuery(IQueryable<Team> query)
    {
        return 
            query.select<Team, TeamBE> (team => 
               new TeamBE
               {
                  TeamID = team.TeamID,
                  Description = team.Description 
               }
    }
