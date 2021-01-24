    public class Team
    {
        public string TeamName { get; set; }
        public int TeamId { get; set; }
        public List<Match> Matches { get; set; }
    }
    public class Match
    {
        public string MatchName { get; set; }
        public int Season { get; set; }
    }
    var teams = new List<Team> {
        new Team
        {
            TeamName = "Team 1",
            TeamId = 1,
            Matches = new List<Match>
            {
                 new Match{ MatchName="Match 11" , Season=1 },
                 new Match{ MatchName="Match 12" , Season=2 }
            }
        },
        new Team
        {
            TeamName = "Team 2",
            TeamId = 2,
            Matches = new List<Match>
            {
                new Match{ MatchName="Match 21" , Season=1 },
                new Match{ MatchName="Match 22" , Season=2 }
            }
        }
    };
    List<Match> team1seazon2 = teams.Where(t => t.TeamId == 1).SelectMany(t => t.Matches).Where(m => m.Season == 2).ToList();
