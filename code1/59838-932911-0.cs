    private IEnumerable<TeamRank> GetRankings(Dictionary<TournamentTeam, double> wins, Dictionary<TournamentTeam, double> scores)
    {
        var overallRank = 1;
        return
            from team in wins.Keys
            let teamValues = new { Wins = wins[team], TotalScore = scores[team] }
            group team by teamValues into rankGroup
            orderby rankGroup.Key.Wins descending, rankGroup.Key.TotalScore descending
            let currentRank = overallRank++
            from team in rankGroup
            select new TeamRank(team, currentRank, rankGroup.Key.Wins, rankGroup.Key.TotalScore);
    }
