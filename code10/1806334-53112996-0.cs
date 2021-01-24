	public static void test()
    {
        int Loop = 0;
	    CancellationTokenSource cts = new CancellationTokenSource();
        Parallel.For(0, 2000, 
              new ParallelOptions() 
              { 
                  MaxDegreeOfParallelism = Environment.ProcessorCount, 
                  CancellationToken = cts.Token 
              }, 
        (i, End) =>
        {
			cts.Token.ThrowIfCancellationRequested();
			
            // ...
            if (i == 1000) // you should be using 'i'
            {
                Console.WriteLine("Break!");
                cts.Cancel();
            }
        });
    }
