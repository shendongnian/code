    private bool isChecked;
    
    public bool IsChecked
    {
      get
       {
         return this.isChecked;
       }
      
      set
      {
        this.isChecked = value;
        OnPropertyChanged["IsChecked"];
      }
    
    }
