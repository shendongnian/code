        Mutex processingMutex = new Mutex(false);
        private void Test2()
        {
            if (!processingMutex.WaitOne(0))
            {
                return;
            }
            try
            {
                //do processing
            }
            finally
            {
                processingMutex.ReleaseMutex();
            }
        }
