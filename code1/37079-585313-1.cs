    public class BulkLoader : IDisposable
    {
        [ThreadStatic]
        private static BulkLoader currentBulkLoader;
        public BulkLoader()
        {
            if (InBulkLoader)
            {
                throw new InvalidOperationException();
            }
            currentBulkLoader = this;
        }
        public void Dispose()
        {
            currentBulkLoader = null;
        }
        public static bool InBulkLoader
        {
             get { return currentBulkLoader != null; }
        }
        public static BulkLoader CurrentBulkLoader
        {
             get { return currentBulkLoader; }
        }
    }
