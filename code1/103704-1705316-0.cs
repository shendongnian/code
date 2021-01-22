    public class WorkUnit : MarshalByRefObject
    {
       private AutoResetEvent _event = new AutoResetEvent(false);
    
       public void Run()
       {
         WebClient wb = new WebClient();
         wb.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wb_DownloadStringCompleted);
         wb.DownloadStringAsync(new Uri("some uri"));
         
         Console.WriteLine("Waiting for download to comlete...");
         _event.WaitOne();
         Console.WriteLine("done");
       }
    
       void wb_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
       {
         Console.WriteLine("job is done now");
         _event.Set();
       }
     }
