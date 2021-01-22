    public static class FeedBurner
    {
        private static object locker = new object();
        private static string connectionString;
        
        // Since this is a static class, there is no public FeedBurner()
        // constructor to set AssemblyConfigManager.OnModified's value.
        static FeedBurner()
        {
            AssemblyConfigManager.OnModified = () =>
            {
                lock (locker)
                {
                    FeedBurner.connectionString = AssemblyConfigManager.Setting("ConnectionString");
                }
            };
        }
        public static FeedBurnerDataContext CreateDataContext()
        {
            lock (locker)
            {
                return new FeedBurnerDataContext(FeedBurner.connectionString);
            }
        }
