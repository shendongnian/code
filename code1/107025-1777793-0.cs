    namespace ConcurrentTest
    {
        class ValType : IDisposable
        {
            public int I { get; set; }
            public int Mem()
            {
                Thread.Sleep(1000);
                return I;
            }
            void IDisposable.Dispose()
            {
                Console.WriteLine("Destroying");
            }
        }
        class Example
        {
            ValType mData = new ValType {I = 0};
            public void Print()
            {
                Console.WriteLine(mData.I);
                Thread.Sleep(2000);
                Console.WriteLine(mData.Mem());
            }
    
            public void Update()
            {    
                var data = new ValType() { I = 1 };
                Interlocked.Exchange(ref mData, null);
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var e = new Example();
                var t = new Thread(new ThreadStart(e.Print));
                t.Start();
                e.Update();
                t.Join();
                Console.ReadKey(false);
            }
        }
    }
