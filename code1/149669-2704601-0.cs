    private void displayResultsButton_Click(object sender, EventArgs e) {
        Game game = new Game("Home", 10, "Away", 12);
    
        gameResultsListView.Items.Clear();
        //You need this so that the subitems are also displayed, otherwise
        //only the main item will show in the listview
        gameResultsListView.View = View.Details;
    
        ListViewItem row = new ListViewItem("Game 1");
        row.SubItems.Add(game.HomeTeam.ToString());
        row.SubItems.Add(game.HomeScore.ToString());
        row.SubItems.Add(game.AwayTeam.ToString());
        row.SubItems.Add(game.AwayScore.ToString());
    
        //The main item and each subitem get a column in the listView
        gameResultsListView.Columns.Add("Game", -2, HorizontalAlignment.Left);
        gameResultsListView.Columns.Add("HomeTeam", -2, HorizontalAlignment.Left);
        gameResultsListView.Columns.Add("HomeTeamScore", -2, HorizontalAlignment.Left);
        gameResultsListView.Columns.Add("AwayTeam", -2, HorizontalAlignment.Left);
        gameResultsListView.Columns.Add("AwayTeamScore", -2, HorizontalAlignment.Left);
    
        gameResultsListView.Items.Add(row);
    }
