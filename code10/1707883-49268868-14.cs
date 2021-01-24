    private DataTable GetGridDT() {
      DataTable dt = new DataTable();
      SetDataTableColumnsAndRows(dt);
      FillRows(dt);
      return dt;
    }
    private void SetDataTableColumnsAndRows(DataTable dt) {
      int totalRows = 0;
      foreach(TeamStat curTeam in TeamStats) {
        dt.Columns.Add(curTeam.TeamName, typeof(string));
        totalRows = Math.Max(totalRows, curTeam.TeamStats.Count);
      }
      // set rows here to max length to avoid having to check for different length stats
      for (int i = 0; i < totalRows; i++) {
        dt.Rows.Add();
      }
    }
