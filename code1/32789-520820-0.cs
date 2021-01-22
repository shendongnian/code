    IEnumerable<TeamCluster> drew = from fixture in fixtures
                             where fixture.Played && (fixture.HomeScore == fixture.AwayScore)
                             select new TeamCluster {
                                 Team1 = fixture.HomeTeam,
                                 Team2 = fixture.AwayTeam,
                                 Score1 = fixture.HomeScore,
                                 Score2 = fixture.AwayScore
                             };
    class TeamCluster {
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
    }
