    using (var debugger = new MdbEng())
    {
      var dummy = new Thread(() => {});
      dummy.Name = "Dummy Thread";
    
      // Get all thread objects in all AppDomains
      var threads = debugger.GetObjects("System.Threading.Thread", true);
    		   
      foreach (Thread t in threads)
      {
    	Console.WriteLine("Managed thread {0} has Name {1}", t.ManagedThreadId, t.Name);
      }
      GC.KeepAlive(dummy);
    }
