    private ChangedEventHandler changedHandler;
    public event ChangedEventHandler Changed
    {
       add
       {
           lock(this)
           {
               changedHandler += value;
           }
       }
       remove
       {
           lock(this)
           {
               changedHandler -= value;
           }
       }
    }
