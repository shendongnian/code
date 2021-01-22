    public string CurrentGridID
    {
      get;
      set;
    }
    
    public void ModifyGrid()
    {
      //make changes to the grid properties
      GridView grid = Page.FindControl(CurrentGridID);
      grid.AutoGenerateColumns = false;
    }
