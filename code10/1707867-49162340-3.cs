    private void button1_Click(object sender, EventArgs e) {
      List<string> atlantaData = GetDataForTeam("Atlanta Hawks", "Boston Celtics");
      List<string> bostonData = GetDataForTeam("Boston Celtics", "Brooklyn Nets");
      List<string> brooklynData = GetDataForTeam("Brooklyn Nets", "Charlotte Hornets");
      TeamDataTable = GetTable();
      FillTable(TeamDataTable, atlantaData, bostonData, brooklynData);
      dataGridView2.DataSource = TeamDataTable;
    }
