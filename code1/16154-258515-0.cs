    public bool IsDebugMode
    {
      get
      {
    #if DEBUG 
        return true;
    #else
        return false;
    #endif
      }
    }
