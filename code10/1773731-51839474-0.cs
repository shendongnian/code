        ManualResetEvent mre = new ManualResetEvent(false);
        void Foo()
        {
            new Thread(() => 
            {
                while (mre.WaitOne())
                {
                    /*process queue item*/
                    if (/*queue is empty*/)
                    {
                        mre.Reset();
                    }
                }
            }) { IsBackground = true }.Start();
        }
        void AddItem()
        {
            /*queue add item*/
            mre.Set();
        }
