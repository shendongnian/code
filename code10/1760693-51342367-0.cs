    class Program
    {
        static void Main(string[] args)
        {
            new Test().TestIt();
            Console.Read();
        }
    }
    class Test
    {
        public int TestIt()
        {
            using (ManagedObject obj = new ManagedObject())
            { 
                int usualNumber = 0;       
                return usualNumber;
            }
        }
    }
    internal class ManagedObject : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposed");
        }
    }
