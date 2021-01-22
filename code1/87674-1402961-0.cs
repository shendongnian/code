    static int _globalId = 0;
    public static void Process(object state)
    {    
      // each queued Process call gets its own player ID to fetch
      processId = InterlockedIncrement(ref _globalId); 
      var s = StatsFecther("byId", processId); //returns all player stats 
         
      Console.WriteLine("Account: " + s.nickname);    
      Console.WriteLine("ID: " + s.account_id);    
      Console.ReadLine();
    }
