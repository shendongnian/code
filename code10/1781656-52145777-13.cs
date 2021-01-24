    public ViewModel()
    {   
        FillList();
        Nodes.Clear();// You could do this if you need it to be cleared
        UpdaterEvent.DataUpdated += OnDataUpdated;        
    }
    private void OnDataUpdated(object sender, EventArgs e)
    {
      FillList();
    }
