    public static class JobDoerFactory
    {
        static Dictionary<Guid, JobDoer> cache;
        static JobDoerFactory()
        {
            // Building the cache is slow, but it will only run once 
            // during the lifetime of the AppDomain.
            cache = BuildCache();
        }
        public static JobDoer GetInstanceById(Guid jobDoerId)
        {
            // Retrieving a JobDoer is as fast as using a switch statement.
            return cache[jobDoerId];
        }
        private static Dictionary<Guid, JobDoer> BuildCache()
        {
            // See implementation below.
        }
    }
