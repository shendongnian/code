    using System;
    internal sealed class Program : IDisposable
    {
        private readonly string _instanceName;
        public Program(string instanceName)
        {
            _instanceName = instanceName;
            Console.WriteLine($"Initializing the '{_instanceName}' instance");
        }
        ~Program()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.WriteLine($"Releasing the '{_instanceName}' instance's managed resources");
            }
            Console.WriteLine($"Releasing the '{_instanceName}' instance's unmanaged resources");
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("Main started");
            Program p0 = new Program(nameof(p0));
            using (Program p1 = new Program(nameof(p1)))
            {
                Console.WriteLine("Outer using block started");
                using (Program p2 = new Program(nameof(p2)))
                {
                    Console.WriteLine("Inner using block started");
                    Console.WriteLine("Inner using block ended");
                }
                Console.WriteLine("Outer using block ended");
            }
            Console.WriteLine("Main ended");
        }
    }
