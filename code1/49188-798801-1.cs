    public static class ThreadingHelper_NativeMethods
    {
       [DllImport("user32.dll")]
       public static extern bool IsGUIThread(bool bConvert);
    }
         // This code forces initialization of .NET BroadcastEventWindow to the UI thread.
         // http://social.msdn.microsoft.com/Forums/en-US/netfxbcl/thread/fb267827-1765-4bd9-ae2f-0abbd5a2ae22
         if (ThreadingHelper_NativeMethods.IsGUIThread(false))
         {
            Microsoft.Win32.SystemEvents.InvokeOnEventsThread(new MethodInvoker(delegate()
            {
               int x = 0;
            }));
         }
