    namespace TimedReadLine
    {
    public static class Console
    {
       private delegate string ReadLineInvoker ();
    
       public static string
       ReadLine (int timeout)
       {
          return ReadLine (timeout, null);
       }
    
       public static string
       ReadLine (int timeout, string @default)
       {
          var  rli = new ReadLineInvoker (System.Console.ReadLine);
          var  iar = rli.BeginInvoke (null, null);
    
          return !iar.AsyncWaitHandle.WaitOne (new System.TimeSpan (0, 0, timeout))
             ? @default : rli.EndInvoke (iar);
       }
    }
    }
