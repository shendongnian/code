    List<Bar> bars = new List<Bar>();
    int numFilesLeft = 0;
    ManualResetEvent isWorkDone = new ManualResetEvent(false);
    
    Interlocked.Increment(ref numFilesLeft);
    try
    {
    foreach (string dirName in Directory.GetDirectories(@"c:\Temp"))
    {
        foreach (string file in Directory.GetFiles(dirName))
        {
            string temp = file;
            Interlocked.Increment(ref numFilesLeft);
            ThreadPool.QueueUserWorkItem(delegate
            {
                try
                {
                     ...
                }
                finally
                {
                    if (Interlocked.Decrement(ref numFilesLeft) == 0)
                    {
                        isWorkDone.Set();
                    }
                }
            });
        }
    }
    }
    finally
    {
     if (0 == Interlocked.Decrement(ref numFilesLeft))
     {
       isWorkDone.Set ();
     }
    }
    
    ...
