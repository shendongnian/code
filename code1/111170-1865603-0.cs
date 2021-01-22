    public class MyLongTunningTask
    {
       public MyLongRunninTask() {}
       prop bool Cancel {get; set; }
    
       public void ExecuteLongRunningTask()
       {
         while(!this.Cancel)
         {
             // Do something long running.
            // you may still like to check Cancel periodically and exit gracefully if its true
         }
       }
    }
