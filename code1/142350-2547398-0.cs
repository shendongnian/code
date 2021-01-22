    public class LeaguePosition
    {
        public int Position { get; set; }
        public string Team { get; set; }
     }
    List<LeaguePosition> League = List<LeaguePosition>();
    League.Add(new LeaguePosition() { Position = 1, Team = "Villa" });
    League.Add(new LeaguePosition() { Position = 2, Team = "Wolves" });
    LeaguePosition.Sort((teamA, teamB) => teamA.Position.CompareTo(teamB.Position));
