    public class TeamStat {
      public string TeamName { get; set; }
      public List<string> TeamStats { get; set; }
      public TeamStat(string teamName) {
        TeamName = teamName;
        TeamStats = new List<string>();
      }
      public TeamStat() {
        TeamName = "";
        TeamStats = new List<string>();
      }
    }
