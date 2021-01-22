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
          var  rli = new ReadLineInvoker (ReadLine);
          var  iar = rli.BeginInvoke (null, rli);
          var  waitHandle = iar.AsyncWaitHandle;
          var  timedOut =
             !waitHandle.WaitOne (new System.TimeSpan (0, 0, timeout));
    
          return timedOut
             ? @default : ((ReadLineInvoker) iar.AsyncState).EndInvoke (iar);
       }
    
       private static string
       ReadLine ()
       {
          return System.Console.ReadLine ();
       }
    }
    }
