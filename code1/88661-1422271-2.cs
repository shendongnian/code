    static class TfsFactory
    {
      public static ITfs instance;
    
      static TfsFactory()
      {
        ... code here to set the instance
        either to an instance of the Tfs class
        or to an instance of the NoTfs class ...
      }
    }
