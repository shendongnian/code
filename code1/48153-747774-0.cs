    public static class Int32Sequencer
    {
        private static Int32 lastSequence = Int32.MinValue;
        private static Object lockObject = new Object();
        public static Int32 GetNextSequence()
        {
            lock (lockObject)
            {
                unchecked { lastSequence++; }
                return lastSequence;
            }
        }
    }
