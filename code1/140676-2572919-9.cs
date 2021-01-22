    public interface IFoo : IDisposable
    {
        void Test();
    }
    public class Foo : IFoo
    {
        private static int count = 0;
        private int num;
        public Foo()
        {
            num = Interlocked.Increment(ref count);
        }
        public void Dispose()
        {
            Console.WriteLine("Goodbye from Foo #{0}", num);
        }
        public void Test()
        {
            Console.WriteLine("Hello from Foo #{0}", num);
        }
    }
