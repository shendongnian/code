     private string timePortModuleIsUp;
     /// <summary>
     /// Gets / Sets how long the port module has been booted for.
     /// </summary>
     public string TimePortModuleIsUp
     {
      get
      {
           return timePortModuleIsUp;
      }
      Set
      {
           timePortModuleIsUp = value;
           OnPropertyChanged("TimePortModuleIsUp");
      }
     }
