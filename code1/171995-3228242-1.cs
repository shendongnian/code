    class MyClass
    {  
        // set the reset event to be signalled initially, thus allowing work until pause is called.
        ManualResetEvent wait_handle = new ManualResetEvent (true);
        void Start()
        {
            Thread thread = new Thread(Work);
            thread.Start();
        }
        void Pause()
        {
            wait_handle.Reset();
        }
        void Resume()
        {
            wait_handle.Set();
        }
        private void Work()
        {
            for(int i = 0; i < 1000000; i++)
            {
                // as long as this wait handle is set, this loop will execute.
                // as soon as it is reset, the loop will stop executing and block here.
                wait_handle.WaitOne();
                Console.WriteLine(i);
            }
        }
    }
