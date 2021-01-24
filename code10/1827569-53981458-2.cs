    public bool IsSelected 
    { 
      get => this.isSelected; 
      set 
      { 
        this.isSelected = value;  
        OnPropertyChanged(); 
      }
    }
