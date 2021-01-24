    // removed 'async' here, since we're not awaiting anything.
    // using 'async' is preferred, but this is to demonstrate a point about
    // using ContinueWith and un-awaited calls
    public Task Call_A_ToTemp()
    {
       Console.WriteLine("Making call A to a fellow grain");
       IGrainB grain = this.GrainFactory.GetGrain<IGrainB>(1);
    
       // Note the 'return' here
       return grain.CallA().ContinueWith((t)=>
       {
         if(t.IsFaulted)
         {
           // Silo message timeout is 32s so t.IsFaulted is true
           Console.WriteLine("Task Faulted");
           Call_A_ToTemp();
         }
        });
    }
