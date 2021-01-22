    public class SomeClass : IDisposable
        {
            /// <summary>
            /// As usually I don't care was object disposed or not
            /// </summary>
            public void SomeMethod()
            {
                if (_disposed)
                    throw new ObjectDisposedException("SomeClass instance been disposed");
            }
            public void Dispose()
            {
                Dispose(true);
            }
            private bool _disposed;
            protected virtual void Dispose(bool disposing)
            {
                if (_disposed)
                    return;
                if (disposing)//we are in the first call
                {
                }
                _disposed = true;
            }
        }
