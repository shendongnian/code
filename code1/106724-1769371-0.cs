    public class DisposableClass : IDisposable
    {
        public static bool WasDisposed { get; private set;}
    
        public void Dispose()
        {
            WasDisposed = true;
        }
    }
