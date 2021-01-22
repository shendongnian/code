    public GridView CurrentGrid
    {
      get;
      set;
    }
    
    public void ModifyGrid()
    {
      //make changes to the grid properties
      CurrentGrid.AutoGenerateColumns = false;
    }
