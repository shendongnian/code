    public sealed class Foo : IDisposable
    {
        private bool disposed;
        private FileStream stream;
        // Other code
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }
            stream.Dispose();
            disposed = true;
        }
    }
