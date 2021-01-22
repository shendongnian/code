    [TestFixture]
    public class SharedRefTest
    {
        public class MyDisposable : IDisposable
        {
            private bool _disposed = false;
            private string _id;
            public MyDisposable(string id) { _id = id; }
            protected virtual void Dispose(bool disposing)
            {
                if (!_disposed)
                {
                    if (disposing)
                    {
                        Console.WriteLine("{0}: Disposing {1}", Thread.CurrentThread.ManagedThreadId, _id);
                    }
                    _disposed = true;
                }
            }
            public void Dispose()
            {
                Dispose(true);
            }
            public override string ToString()
            {
                return _id;
            }
        }
        [Test]
        public void Run()
        {
            Task t1, t2, t3;
            // create 2 objects
            Console.WriteLine("{0}: starting initial scope", Thread.CurrentThread.ManagedThreadId);
            using (var o1 = SharedRef.Create(new MyDisposable("o1")))
            using (var o2 = SharedRef.Create(new MyDisposable("o2")))
            {
                // and 3 sharedrefs, which will be Disposed in 3 separate threads
                var p1 = SharedRef.Create(o1);
                var p2a = SharedRef.Create(o2);
                var p2b = SharedRef.Create(o2);
                t1 = Task.Run(() =>
                {
                    using (p1)
                    {
                        Console.WriteLine("{0}: in another thread, using o1", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                        Console.WriteLine("{0}: in another thread, exiting scope", Thread.CurrentThread.ManagedThreadId);
                    }
                });
                t2 = Task.Run(() =>
                {
                    using (p2a)
                    {
                        Console.WriteLine("{0}: in another thread, using o2", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                        Console.WriteLine("{0}: in another thread, exiting scope", Thread.CurrentThread.ManagedThreadId);
                    }
                });
                t3 = Task.Run(() =>
                {
                    using (p2b)
                    {
                        Console.WriteLine("{0}: in another thread, using o2", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(1000);
                        Console.WriteLine("{0}: in another thread, exiting scope", Thread.CurrentThread.ManagedThreadId);
                    }
                });
                Console.WriteLine("{0}: exiting initial scope", Thread.CurrentThread.ManagedThreadId);
            }
            t1.Wait();
            t2.Wait();
            t3.Wait();
        }
    }
