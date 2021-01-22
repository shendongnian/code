    public class Downloader
    {
     private int fileCount = 0;
     private AutoResetEvent sync = new AutoResetEvent(false);
     
     private void StartNewDownload(object o)
     {
      if (Interlocked.Increment(ref this.fileCount) > 5) this.sync.WaitOne();
    
      WebClient downloadClient = new WebClient();
      downloadClient.OpenReadCompleted += downloadClient_OpenReadCompleted;
      downloadClient.OpenReadAsync(new Uri(o.ToString(), UriKind.Absolute));
     }
     
     private void downloadClient_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
     {
      try
      {
       // Download logic goes here.
      }
      catch {}
      finally
      {
       this.sync.Set();
       Interlocked.Decrement(ref this.fileCount);
      }
     }
       
     public void Run()
     {
      string o = "url1";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      Thread.Sleep(100);
      
      o = "url2";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      
      o = "url3";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      Thread.Sleep(200);
      
      o = "url4";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      
      o = "url5";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      
      o = "url6";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      
      o = "url7";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      Thread.Sleep(200);
      
      o = "url8";
      System.Threading.ThreadPool.QueueUserWorkItem(this.StartNewDownload, o);
      Thread.Sleep(400);
     }
    }
