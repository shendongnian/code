    // A method which runs in a thread
        public void Run()
        {
            startSignal.WaitOne();
            while(running)
            {
                startSignal.WaitOne();
                //... some code
            }
            latch.Signal();
        }
