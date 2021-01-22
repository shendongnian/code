    public RelayCommand<UIElement> LoadedCommand {get;private set;} 
    
    public ProjectGridViewModel() 
    { 
      LoadedCommand = new RelayCommand<UIElement>(e =>  
        { 
          this.DoLoaded(e); 
        } 
      ); 
    } 
      
    Grid _projectGrid = null; 
    public void DoLoaded(UIElement e) 
    { 
      _projectGrid = e; 
    } 
