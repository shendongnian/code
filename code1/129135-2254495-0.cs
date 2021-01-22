    private int _Whatever; 
    public int Whatever
    {
        get {return _Whatever;}
        set 
        {
            if(value != _Whatever)
            {  
              // It changed do something here...
              // maybe fire an event... whatever
              
            } 
            _Whatever = value;
        }
    }
