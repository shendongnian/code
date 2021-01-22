    using( var bt = new BachtuocvnDataContext() )
    {
        var matchedTeam = bt.Bet_Leagues_Teams.Single( lt => lt.LeagueID == leagueID );
        matchedTeam.TeamID = teamID;
        bt.SubmitChanges( ConflictMode.ContinueOnClonflict );
    }
