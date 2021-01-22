    static class Program
    {
        static IEnumerable<Result> GetResults(Dictionary<TournamentTeam, double> wins, Dictionary<TournamentTeam, double> scores)
        {
            int r = 1;
            double lastWin = -1;
            double lastScore = -1;
            int lastRank = -1;
            foreach (var rank in from name in wins.Keys
                                 let score = scores[name]
                                 let win = wins[name]
                                 orderby win descending, score descending
                                 select new Result { Name = name, Rank = r++, Score = score, Win = win })
            {
                if (lastWin == rank.Win && lastScore == rank.Score)
                {
                    rank.Rank = lastRank;
                }
                lastWin = rank.Win;
                lastScore = rank.Score;
                lastRank = rank.Rank;
                yield return rank;
            }
        }
    }
    class Result
    {
        public TournamentTeam Name;
        public int Rank;
        public double Score;
        public double Win;
    }
