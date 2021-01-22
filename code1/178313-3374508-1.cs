    [TestMethod]
    public void something()
    {
       Loop.LoopMe(TestMethod,3);            
       Assert.Something();
    }
    internal class Loop
    {
        public static void LoopMe(Action action, int maxRetry)
        {
            Exception lastException = null;
            while (maxRetry > 0)
            {
                try
                {
                    action();
                    return;
                }
                catch (Exception e)
                {
                    lastException = e;
                    maxRetry--;                    
                }                
            }
            throw lastException;
        }
    }
