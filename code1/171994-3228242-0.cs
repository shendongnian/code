    class MyClass
    {
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
                wait_handle.WaitOne();
                Console.WriteLine(i);
            }
        }
    }
