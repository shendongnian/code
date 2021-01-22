    static internal void Main()
            {
                try
                {
                    throw new Exception();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
    
                    // The debuger  will never go beyond
                    // the throw statement and terminate
                    // the process. Why?
                    Environment.FailFast("Oops");
                    throw;
                }
            }
