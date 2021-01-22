    using System.Runtime.InteropServices;
    
    class Win32Call
    {
    [DllImport("user32.dll")]
       public static extern int RegisterWindowMessage(String strMessage);
    }
    
    // In your application you will call
    
    Win32Call.RegisterWindowMessage("QueryCancelAutoPlay");
