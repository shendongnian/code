    private int syncPoint = 0;
    private void Loop()
        {
            int sync = Interlocked.CompareExchange(ref syncPoint, 1, 0);
             //ensures that only one timer set the syncPoint to  1 from 0
            if (sync == 0)
            {
                try
                {
                   ...
                }
                catch (Exception pE)
                {
                   ...  
                }
                syncPoint = 0;
            }
           
        }
