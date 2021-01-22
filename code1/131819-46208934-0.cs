    public static class Singleton<T> 
    {
        private static readonly object Sync = new object();
        public static T GetSingleton(ref T singletonMember, Func<T> initializer)
        {
            if (singletonMember == null)
            {
                lock (Sync)
                {
                    if (singletonMember == null)
                        singletonMember = initializer();
                }
            }
            return singletonMember;
        }
    }
