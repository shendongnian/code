    private List<string> _outcomeDataSource;
    
    private void Form1_Load(object sender, EventArgs e)
    {
        _outcomeDataSource = new List<string>;
        _outcomeDataSource.Add("");
        _outcomeDataSource.Add("Unresolved");
        _outcomeDataSource.Add("Pending");
        _outcomeDataSource.Add("Resolved");
        ResolvedColumn.DataSource = _outcomeDataSource;
        ResolvedColumn.PropertyName = "Outcome";
    }
