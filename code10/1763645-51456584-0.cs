    private Augen _eyeobj;
    public Augen Eyeobj 
          {
            get
            {
                return _eyeobj;
            }
            set
            {
             if(_eyeobj != value)
             {
                _eyeobj  = value;
                NotifyPropertyChanged("Eyeobj");
             }
            }
           }
