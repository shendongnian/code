    public static class MyCLRClass
    {
        private static readonly ReaderWriterLock rwlock = new ReaderWriterLock();
        private static readonly ArrayList list = new ArrayList();
        private static void AddToList(object obj)
        {
            rwlock.AcquireWriterLock(1000);
            try
            {
                list.Add(obj);
            }
            finally
            {
                rwlock.ReleaseLock();
            }
        }
        [SqlProcedure(Name="MyCLRProc")]
        public static void MyCLRProc()
        {
            rwlock.AcquireReaderLock(1000);
            try
            {
                SqlContext.Pipe.Send(string.Format("items in list: {0}", list.Count));
            }
            finally
            {
                rwlock.ReleaseLock();
            }
        }
    }
