    [DllImport("kernel32")]    
    public extern static bool FreeLibrary(int hLibModule);
    [DllImport("kernel32")]    
    public extern static int LoadLibrary(string lpLibFileName);
    
          
    
    public bool IsDllRegistered(string DllName)    
    {
    
          int libId = LoadLibrary(DllName);    
          if (libId>0) FreeLibrary(libId);    
          return (libId>0);    
    }
