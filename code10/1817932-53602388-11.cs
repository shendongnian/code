    public ViewModel() //constructor
    {
      _copy = new CopyCommand(this);
     
    }
    public CopyCommand Copy
    {
         get
         {
             return _copy;
         }
    }
