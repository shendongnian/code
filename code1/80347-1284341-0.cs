        static int wrkThreads = 0;
        static readonly EventWaitHandle exit = new ManualResetEvent(false);
        static readonly object syncLock = new object();
        static void Main( string[] items )
        {
            wrkThreads = items.Length;
            foreach ( var item in items )
                ThreadPool.QueueUserWorkItem(( DoWork ), item);
            exit.WaitOne();
        }
        static void DoWork( object obj )
        {
            lock ( syncLock ) {
                /* Do your file work here */
            }
            if ( Interlocked.Decrement(ref wrkThreads) == 0 )
                exit.Set();
        }
