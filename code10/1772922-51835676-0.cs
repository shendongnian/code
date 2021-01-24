    public class myProcess
    {
      private static Hashtable _sessions;
    
      public static Hashtable sessions
      {
         get { return _sessions; }
         set { _sessions = value; }
      }
        
      public static void run(string name, string _Process) 
      {
         Process p = Process.Start(name, _Process);
         sessions.Add(name, p.Id);
         p.WaitForInputIdle();
      }
    }
