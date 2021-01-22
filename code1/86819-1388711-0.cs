    //FirstControl
    public event EventHandler SelectionChanged;
    private void OnOptionButtonSelectionChange(....)
    {
      if (SelectionChanged != null)
        SelectionChanged(this, EventArgs.Empty);
    }
    
    //SecondControl
    public void Setup()
    {
      firstControlInstance.SelectionChanged += new EventHandler(manage_SelectionChanged);
    }
    
    private void manage_SelectionChanged(Object sender, EventArgs e)
    {
    
    }
