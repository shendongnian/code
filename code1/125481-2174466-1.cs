    public static class PRManager
    {
        private static XmlJobListProcessor instance = new XmlJobListProcessor();
        private static object lockobj = new object();
        public static void ProcessList(SPList list)
        {
             bool acquired = Monitor.TryEnter(lockobj);
                try
                {
                    if (acquired)
                    {
                        instance.ProcessList(list);
                    }
                }
                catch (ArgumentNullException)
                {
                }
                finally
                {
                    Monitor.Exit(lockobj);
                }
        }
    }
