    Random rand = new Random()
    public void KillCore()
    {
         long num = 0;
         while(true)
         {
              num += rand.Next(100, 1000);
              if (num > 1000000) { num = 0; }
         }
    }
    
    public void Main()
    {
         List<Thread> threads = new List<Thread>();
         while (true)
         {
              threads.Add( new Thread( new ThreadStart(KillCore) ) );
         }
    }
