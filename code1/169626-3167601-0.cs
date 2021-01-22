    private static object lockObject = new object();
    public void DoSomething()
    {
        if (System.Threading.Monitor.TryEnter(lockObject))
        {
            try
            {
                // critical stuff 
            }
            finally
            {
                System.Threading.Monitor.Exit(lockObject);
            }
        }
    }
