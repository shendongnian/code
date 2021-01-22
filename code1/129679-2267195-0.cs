    class static UniqueIDGenerator 
    {
        // reads Max+1 from DB on startup
        private static long m_NextID = InitializeFromDatabase(); 
        public static long GetNextID() { return Interlocked.Increment( ref m_NextID ); }
    }
