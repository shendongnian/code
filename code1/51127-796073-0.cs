    private static ManualResetEvent manual = new ManualResetEvent(false);
    private static int count = 0;
    
    public void RunJobs( List<JobState> states )
    {
         ThreadPool.SetMaxThreads( 15, 15 );
         foreach( var state in states )
         {
              Interlocked.Increment( count );
              ThreadPool.QueueUserWorkItem( Job, state );
         }
        manual.WaitOne();
    }
    private void Job( object state )
    {
        // run job
        
        Interlocked.Decrement( count );
        if( Interlocked.Read( count ) == 0 ) manual.Set();
    }
