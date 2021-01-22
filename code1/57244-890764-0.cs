    using System;
    using System.Threading;
    using System.Diagnostics;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                Thread t = new Thread(GCThread);
                t.IsBackground = true;
                t.Start();
    
                SomeClass sc = new SomeClass();
                sc.Test();
                Console.Out.WriteLine("Ending");
            }
    
            private static void GCThread()
            {
                while (true)
                {
                    GC.Collect();
                }
            }
        }
    
        public class Disposable : IDisposable
        {
            public Boolean IsDisposed { get; set; }
    
            public void Dispose()
            {
                IsDisposed = true;
            }
        }
    
        public class SomeClass
        {
            private Disposable _Collectable = new Disposable();
    
            ~SomeClass()
            {
                _Collectable.Dispose();
                Console.Out.WriteLine("Finalized");
            }
    
            public void Test()
            {
                Console.Out.WriteLine("Test()");
                Disposable c = _Collectable;
                Debug.Assert(!_Collectable.IsDisposed);
                Thread.Sleep(100);
                Console.Out.WriteLine("c.IsDisposed: " + c.IsDisposed);
            }
        }
    
    }
