    public void replay() 
    {        
        Thread.Sleep(5000);
        DateTime start = DateTime.Now;      
        for (int i = 0; i < 1000; i++) 
        {            
              Console.WriteLine(string.Format("Exec:{0} - {1} ms",
                    i, DateTime.Now - start));
              start = DateTime.Now;
              Thread.Sleep(300);        
        }
    }
