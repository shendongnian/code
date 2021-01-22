    public delegate void AsyncTask(object state);
    
    public void Method1(object state) .....
    
    public void Method2(object state) .....
    
    
    public void RunAsyncAndWait(){
    
       AsyncTask ac1 = new AsyncTask(Method1);
       AsyncTask ac2 = new AsyncTask(Method2);
    
       WaitHandle[] waits = new WaitHandle[2];
    
       IAsyncResult r1 = ac1.BeginInvoke( someData , null , null );
       IAsyncResult r2 = ac2.BeginInvoke( someData , null , null );
    
       waits[0] = r1.AsyncWaitHandle;
       waits[1] = r2.AsyncWaitHandle;
    
       WaitHandle.WaitAll(waits);
    
    }
