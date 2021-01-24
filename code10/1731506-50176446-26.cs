    public class Example2 : Example
    {
        private CancellationTokenSource uploadCancellationTokenSource = new CancellationTokenSource();
        public new void Dispose()
        {
            uploadCancellationTokenSource.Dispose();
            base.Dispose();
        }
    }
