    // Use ConcurrentQueue to enable safe enqueueing from multiple threads.
    var exceptions = new ConcurrentQueue<Exception>();
    // Execute the complete loop and capture all exceptions.
    Parallel.ForEach(data, d =>
    {
        try
        {
            // Cause a few exceptions, but not too many.
            if (d < 3)
                throw new ArgumentException($"Value is {d}. Value must be greater than or equal to 3.");
            else
                Console.Write(d + " ");
        }
        // Store the exception and continue with the loop.                    
        catch (Exception e)
        {
            exceptions.Enqueue(e);
        }
    });
    Console.WriteLine();
    // Throw the exceptions here after the loop completes.
    if (exceptions.Count > 0) throw new AggregateException(exceptions);
