    private static void ThreadFunc()
    {
        ulong counter = 0;
        while (true)
        {
            try
            {
                try
                {
                    Console.WriteLine("{0}", counter++);
                }
                catch (ThreadAbortException)
                {
                    // Attempt to swallow the exception and continue.
                    Console.WriteLine("Abort!");
                }
            }
            catch (ThreadAbortException)
            {
                Console.WriteLine("Do we get here?");
            }
        }
    }
