        private bool isProcessing = false;
        private object readLock = new object();
        private object processingLock = new object();
        private void Test()
        {
            Monitor.Enter(readLock);
            if (isProcessing)
            {
                Monitor.Exit(readLock);
                return;
            }
            lock (processingLock)
            {
                isProcessing = true;
                Monitor.Exit(readLock);
                try
                {
                    //do something
                }
                finally
                {
                    isProcessing = false;
                }
            }
        }
