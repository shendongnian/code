    private List<string> GetDataForTeam(string targetTeam, string endTeam) {
      List<string> teamData = new List<string>();
      int targetTeamStart = node.InnerText.IndexOf(targetTeam);
      int targetTeamLength = node.InnerText.IndexOf(endTeam) - targetTeamStart;
      string targetTeamOutput = node.InnerText.Substring(targetTeamStart, targetTeamLength).Replace("TEAM", "").Replace("\"", "").Replace("{:", "").Replace("FPPG:", "").Trim();
      string[] targetTeamSplit = targetTeamOutput.Split(',');
      foreach (string targetTeamStat in targetTeamSplit) {
        if (targetTeamStat != "") {  // <-Delete empty cells here instead of the grid
          teamData.Add(targetTeamStat);
        }
      }
      return teamData;
    }
