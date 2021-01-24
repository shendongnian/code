    private void FillTable(DataTable dt, List<string> atlData, List<string> bostonData, List<string> brookData) {
      int totalRows = Math.Max(atlData.Count, Math.Max(bostonData.Count, brookData.Count));
      DataRow newRow;
      for (int i = 0; i < totalRows; i++) {
        newRow = TeamDataTable.NewRow();
        if (i < atlData.Count)
          newRow["Atlanta"] = atlData[i];
        if (i < bostonData.Count)
          newRow["Boston"] = bostonData[i];
        if (i < brookData.Count)
          newRow["Brooklyn"] = brookData[i];
        TeamDataTable.Rows.Add(newRow);
      }
    }
