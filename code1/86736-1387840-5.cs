    class JobThread{
        static Thread bgThread = null;
        static AutoResetEvent arWait = new AutoResetEvent(false);
    
        public static void ProcessQueue(Job job)
        {
             // insert job in database
             job.InsertInDB();
             // start queue if its not created or if its in wait
             if(bgThread==null){
                  bgThread = new Thread(new ..(WorkerProcess));
                  bgThread.IsBackground = true;
                  bgThread.Start();
             }
             else{
                  arWait.Set();
             }
        }
    
        private static void WorkerProcess(object state){
             while(true){
                  Job job = GetAvailableJob( 
                            IsProcessing = false and IsOver = flase);
                  if(job == null){
                       arWait.WaitOne(10*1000);// wait ten seconds.
                                               // to increase performance
                                               // increase wait time
                       continue;
                  }
                  job.IsRunning = true;
                  job.UpdateDB();
                  try{
                      
                  //
                  //depending upon job type do something...
                  }
                  catch(Exception ex){
                       job.LastError = ex.ToString(); // important step
                       // this will update your error in JobTable
                       // for later investigation
                       job.UpdateDB();
                  }
                  job.IsRunning = false;
                  job.IsOver = true;
                  job.UpdateDB();
             }
        }
    }
