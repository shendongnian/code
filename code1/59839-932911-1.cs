    public class TeamRank
    {
        public TeamRank(TournamentTeam team, int rank, double wins, double totalScore)
        {
            this.Team = team;
            this.Rank = rank;
            this.Wins = wins;
            this.TotalScore = totalScore;
        }
        public TournamentTeam Team { get; private set; }
        public int Rank { get; private set; }
        public double Wins { get; private set; }
        public double TotalScore { get; private set; }
    }
