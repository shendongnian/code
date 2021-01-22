    using System.Timers;
                   
    System.Timers.Timer t1 = new System.Timers.Timer(2*60*1000  /*2mins interval*/);
    t1.Elapsed += new System.Timers.ElapsedEventHandler(t1_Elapsed);
    t1.Start();
        
    void t1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
      //Do ur stuff
    }
