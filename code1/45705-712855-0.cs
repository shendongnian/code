    public class DisposeAnything : IDisposable
    {
        public Action Disposer;
        public void Dispose()
        {
            Disposer();
        }
    }
