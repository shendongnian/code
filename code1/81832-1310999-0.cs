    public static class ThreadTest
    {
        public void Main()
        {
            long exit = 0;
    
            Queue<string> messages = new Queue<string>();
            ManualResetEvent signal1 = new ManualResetEvent();
            ManualResetEvent signal2 = new ManualResetEvent();
    
            signal2.Set();
    
            Thread writer = new Thread(() =>
            {
                while (exit == 0)
                {
                    string value = Console.ReadLine();
                    if (value == "exit")
                    {
                        Interlocked.Exchange(ref exit, 1);
                    }
                    else
                    {
                        messages.Enqueue(value);
                        Console.WriteLine("Written: " + value);
                        signal1.Set();
                    }
    
                    signal2.WaitOne();
                }
            });
    
            Thread reader = new Thread(() =>
            {
                while (exit == 0)
                {
                    signal1.WaitOne();
                    signal2.Reset();
    
                    value = messages.Dequeue();
                    Console.WriteLine("Read: " + value);
    
                    signal2.Set();
                    signal1.Reset();
                }
            });
            reader.Start();
            writer.Start();
        }
    }
