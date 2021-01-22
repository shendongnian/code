    public static class PRManager
    {
        private static XmlJobListProcessor instance = new XmlJobListProcessor();
        private static object lockobj = new object();
        public static void ProcessList(SPList list)
        {
            if (Monitor.TryEnter(lockobj))
            {
                lock (lockobj)
                {
                    instance.ProcessList(list);
                }
            }
        }
    }
