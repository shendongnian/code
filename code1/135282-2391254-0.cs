        object lockObject = new object();
        int WaitCounter = 0;
        void B()
        {
            System.Threading.Interlocked.Increment(ref WaitCounter);
            try
            {
                lock (lockObject)
                {
                }
            }
            finally
            {
                System.Threading.Interlocked.Decrement(ref WaitCounter);
            }
        }
        void C()
        {
            while (true)
            {
                // always attempt to yield to other threads first
                System.Threading.Thread.Sleep(0);
                lock (lockObject)
                {
                    if (WaitCounter > 0)
                        continue;
                    // ...
                    return;
                }
            }
        }
