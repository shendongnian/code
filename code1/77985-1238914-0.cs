    public String Name
    {
        get { return name; }
        set { 
               name = value; 
               OnPropertyChanged("Name");
            }
    }
