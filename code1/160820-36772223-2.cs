    private void indBoxProject_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        int NewProjID = (e.AddedItems[0] as kProject).ProjectID;
        this.MyProject = new kProject(NewProjID);
        LoadWorkPhase();
    }
