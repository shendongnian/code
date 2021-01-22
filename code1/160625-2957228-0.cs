    using System.Diagnostics;
    
    public class Helper
    {
      public static bool IsCurrentAppWeb()
      {
        return Process.GetCurrentProcess().ProcessName == "aspnet_wp"; 
      }
    }
