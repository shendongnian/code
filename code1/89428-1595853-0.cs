    static void timer_Elapsed(object sender, ElapsedEventArgs e)    
    {     
       try
       {
          timer.Stop(); 
          Thread.Sleep(2000);        
          Debug.WriteLine(Thread.CurrentThread.ManagedThreadId);    
       }
       finally
       {
         timer.Start();
       }
    }
