    public static class Singleton<T>
    {
        private static object lockVar = new object();
        private static bool made;
        private static T _singleton = default(T);
    
        /// <summary>
        /// Get The Singleton
        /// </summary>
        public static T Get
        {
            get
            {
                if (!made)
                {
                    lock (lockVar)
                    {
                        if (!made)
                        {
                            ConstructorInfo cInfo = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
                            if (cInfo != null)
                                _singleton = (T)cInfo.Invoke(new object[0]);
                            else
                                throw new ArgumentException("Type Does Not Have A Default Constructor.");
                            made = true;
                        }
                    }
                }
    
                return _singleton;
            }
        }
    }
