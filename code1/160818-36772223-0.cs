    private void indBoxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        string text = (e.AddedItems[0] as kProject).ProjectID.ToString();
        this.MyProject = new kProject(Convert.ToInt32(text));
        LoadWorkPhase();
    }
