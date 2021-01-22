    public myClass : SqlDataReader
    {
        protected overide void Dispose(bool disposing) : Base(disposing)
        {
            myCleanupCode();
        }
        protected overide void Dispose()
        {
            myCleanupCode();
        }
        private myCleanupCode()
        {
            //Do cleanup here so you can make one change that will apply to both cases.
        }
    }
