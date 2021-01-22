                ManualResetEvent[] waitHandles = new ManualResetEvent[]{
                new ManualResetEvent(false),
                new ManualResetEvent(false)
            };
            Thread t1 = new Thread(new ParameterizedThreadStart(delegate(object state)
            {
                ManualResetEvent handle = (ManualResetEvent)state;
                System.Threading.Thread.Sleep(2000);
                handle.Set();
            }));
            Thread t2 = new Thread(new ParameterizedThreadStart(delegate(object state)
            {
                ManualResetEvent handle = (ManualResetEvent)state;
                System.Threading.Thread.Sleep(4000);
                handle.Set();
            }));
            t1.Start(waitHandles[0]);
            t2.Start(waitHandles[1]);
            WaitHandle.WaitAll(waitHandles);
            Console.WriteLine("Finished");
