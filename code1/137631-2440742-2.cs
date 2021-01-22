    public class YourClass : IDisposable
    {
        private OtherDisposableType yourResource;
    
        public YourClass()
        {
            yourResource = new OtherDisposableType();
        }
    
        public void Dispose()
        {
            yourResource.Dispose();
        }
    }
    
