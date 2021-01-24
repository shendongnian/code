    private static object _lockObj = new object();
    private static Form1 _instance = new Form1();
    public static Form1 Instance 
    {
       lock(_lockObj)
       {
          get
          {
             if(_instance == null || _instance.IsDisposed) _instance = new Form1();
             return _instance;
          }
        }
     }
