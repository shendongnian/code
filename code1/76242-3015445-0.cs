    public class A 
    {  
     public void Start(ThreadClass tc) 
     { 
        ManualResetEvent mre = new ManualResetEvent(false);
        WebClient wc = new WebClient(); 
        // progress events are pumped to the ThreadClass which then update the Form2. 
        wc.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(wc_DownloadFileCompleted); 
     
        wc.DownloadFileAsync("Src", "Tgt", mre); 
        mre.WaitOne();
        mre.Close();
     } 
     
     void void wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e) 
     { 
        try 
        { 
         // Do Stuff 
        } 
        finally 
        { 
          (e.UserState as ManualResetEvent).Set();
        } 
     } 
    } 
