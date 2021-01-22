    public class BulkLoader : IDisposable
    {
        [ThreadStatic]
        private static bool inBulkLoader;
        public BulkLoader()
        {
            if (inBulkLoader)
            {
                throw new InvalidOperationException();
            }
            inBulkLoader = true;
        }
        public void Dispose()
        {
            inBulkLoader = false;
        }
        public static bool InBulkLoader
        {
             get { return inBulkLoader; }
        }
    }
