    public class MyLongTunningTask
    {
       public MyLongRunninTask() {}
       public volatile bool Cancel {get; set; }
    
       public void ExecuteLongRunningTask()
       {
         while(!this.Cancel)
         {
             // Do something long running.
            // you may still like to check Cancel periodically and exit gracefully if its true
         }
       }
    }
