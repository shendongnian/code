          private string _subState;    
          public string SubState    
          {
             get { return _subState; }
             set { _subState = value; OnPropertyChanged(); }
          }
