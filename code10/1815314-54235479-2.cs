    class User: INotifyPropertyChanged
    {
      bool _isAuthorized;
      public event PropertyChangedEventHandler PropertyChanged;
      public string Name{get;set;}  
      public string Id{get;set;}
      public bool IsAuthorized
      {
        get=>_isAuthorized;
        set
        { 
          _isAuthorized =value;
           PropertyChanged?.Invoke(nameof(IsAuthorized));
        }
      }
    }
