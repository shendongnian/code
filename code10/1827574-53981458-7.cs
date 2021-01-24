    public bool IsSelected 
    { 
      get => this.isSelected; 
      set 
      { 
        if (value.Equals(this.isSelected)
        {
          return;
        }
        this.isSelected = value;  
        OnPropertyChanged(); 
      }
    }
