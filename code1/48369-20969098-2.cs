    class DependentObject
    {
        public class MyKey : IDisposable
        {
            public MyKey(bool iskey)
            {
                this.iskey = iskey;
            }
            private bool disposed = false;
            private bool iskey;
            public void Dispose()
            {
                if (!disposed)
                {
                    disposed = true;
                    Console.WriteLine("Cleanup {0}", iskey);
                }
            }
            ~MyKey()
            {
                Dispose();
            }
        }
        static void Main(string[] args)
        {
            var dep = new MyKey(true); // also try passing this to cwt.Add
            ConditionalWeakTable<MyKey, MyKey> cwt = new ConditionalWeakTable<MyKey, MyKey>();
            cwt.Add(new MyKey(true), dep); // try doing this 5 times f.ex.
            GC.Collect(GC.MaxGeneration);
            GC.WaitForFullGCComplete();
            Console.WriteLine("Wait");
            Console.ReadLine(); // Put a breakpoint here and inspect cwt to see that the IntPtr is still there
        }
