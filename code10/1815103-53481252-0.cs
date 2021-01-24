    private string _NameFirst;
    public string NameFirst
    {
        get { return _NameFirst; }
        set
        {
            if (value != _NameFirst)
            {
                 _NameFirst = value;
                 NotifyPropertyChanged();
            }
         }
     }
    
     private string _NameSecond;
     public string NameSecond
     {
         get { return _NameSecond; }
         set
         {
             if (value != _NameSecond)
             {
                _NameSecond = value;
                NotifyPropertyChanged();
              }
          }
    }
