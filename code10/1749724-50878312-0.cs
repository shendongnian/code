    public sealed class Singleton : IDisposable
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());
        public static Singleton Instance { get { return lazy.Value; } }
        private Singleton() { }
        ~Singleton()
        {
            Console.WriteLine("Destructor Called."); // Breakpoint here
        }
        void IDisposable.Dispose()
        {
            Console.WriteLine("Dispose Called.");
            GC.SuppressFinalize(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Singleton.Instance.ToString();
            ((IDisposable)Singleton.Instance).Dispose();
            GC.Collect();
        }
    }
