    private string _firstName;
    
    public string FirstName
    {
       get { return _firstname; }
       set
       {
          if (_firstname != value)
          {
              _firstname = value;
              OnPropertyChanged("FirstName")
          }
       }
    }
