    public class LeaguePosition
    {
        public int Position { get; set; }
        public string Team { get; set; }
    }
    List<LeaguePosition> League = new List<LeaguePosition>();
    League.Add(new LeaguePosition() { Position = 2, Team = "Wolves" });
    League.Add(new LeaguePosition() { Position = 3, Team = "Spurs" });
    League.Add(new LeaguePosition() { Position = 1, Team = "Villa" });
            
    League.Sort((teamA, teamB) => teamA.Position.CompareTo(teamB.Position));
