    public sealed class Singleton
    {
        private static readonly Singleton _instance = new Singleton();
     
        private Singleton() { }
     
        public static Singleton Instance
        {
            get
            {
               return _instance;
            }
        }
    
    public static int UserID
    {
      get
      {
         return _instance.GetUserID();
      }
    }
    
    private int GetUserID()
    {
      return 1;
    }
    
    
    }
