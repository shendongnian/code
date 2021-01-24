    public class Example : IDisposable
    {
        private CancellationTokenSource uploadCancellationTokenSource = new CancellationTokenSource();
        public void Dispose()
        {
            uploadCancellationTokenSource.Dispose();
            GC.SuppressFinalize(this);
        }
        ~Example() => Dispose();
    }
