    int count = TOTAL_ITERATIONS;
    var finished = new ManualResetEvent(false);
    for (int i = 0; i < TOTAL_ITERATIONS; i++) 
    { 
      int captured = i; // Use this for variable capturing in the anonymous method.
      ThreadPool.QueueUserWorkItem(
        delegate(object state)
        {
          try
          {
            Console.WriteLine(captured.ToString());
            // Your task goes here.
            // Refer to 'captured' instead of 'i' if you need the loop variable.
            Console.WriteLine(captured.ToString());
          }
          finally
          {
            if (Interlocked.Decrement(ref count) == 0)
            {
              finished.Set();
            }
          }
        });
    }
    finished.WaitOne();
