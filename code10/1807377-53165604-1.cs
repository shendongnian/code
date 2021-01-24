            static void Main(string[] args)
            {
                for (int i = 0; i < 1000; i++)
                {
                    object _lock1 = new object();
                    object _lock2 = new object();
    
                    Thread code1 = new Thread(() =>
                    {
                        lock (_lock1)
                        {
                            lock (_lock2)
                            {
                                Console.WriteLine("A");
                                Thread.Sleep(100);
                            }
                        }
                    });
    
                    Thread code2 = new Thread(() =>
                    {
                        lock (_lock2)
                        {
                            lock (_lock1)
                            {
                                Console.WriteLine("B");
                                Thread.Sleep(100);
                            }
                        }
                    });
    
                    code1.Start();
                    code2.Start();
    
                    code1.Join();
                    code2.Join();
                }
                Console.WriteLine("Done");
            }
