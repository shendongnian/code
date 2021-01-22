    public class Parent : IDisposable
    {
        public string Name
        {
            get
            {
                AssertNotDisposed();
                return name;
            }
            set
            {
                AssertNotDisposed();
                name = value;
            }
        }
        public void Dispose()
        {
            AssertNotDisposed();
            Console.WriteLine("Disposing Parent");
            isDisposed = true;
        }
        private void AssertNotDisposed()
        {
            if(isDisposed)
                throw new ObjectDisposedException("some message");
        }
        private string name;
        private bool isDisposed = false;
    }
