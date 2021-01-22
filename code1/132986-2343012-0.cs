    public static object _lock = new object();
    
    public void Save(..)
    {
       lock(_lock) {
          //check for existence of an ID
          //process accordingly
       }
    }
