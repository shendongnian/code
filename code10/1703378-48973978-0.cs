        static void Main(string[] args)
        {
            // If the task running used 3000ms, stop.
            int timeOut = 3000;
            CancellationTokenSource source = new CancellationTokenSource();
            source.CancelAfter(timeOut);
            CancellationToken token = source.Token;
            token.Register(() =>
            {
                Console.WriteLine("Task Is TimeOut!!!!! Stop");
            });
            //start the task:
            Task.Run(() =>
            {
                Console.WriteLine("Task start");
                Thread thread = Thread.CurrentThread;
                //create a new task listening the token;
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Listening start");
                    while (!token.IsCancellationRequested)
                    {
                        Console.WriteLine("Listening...");
                        Thread.Sleep(800);
                    }
                    Console.WriteLine("Listening End");
                    thread.Abort();
                }, token);
                Stopwatch time = Stopwatch.StartNew();
                #region A long time operation：;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("run...");
                    Thread.Sleep(100);
                }
                #endregion
                time.Stop();
                Console.WriteLine("Task end. cost:{0}", time.ElapsedMilliseconds);
                source.Cancel();
                Console.WriteLine("Task End");
                token.ThrowIfCancellationRequested();
            }, token);
            Console.ReadLine();
        }
