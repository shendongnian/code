    class sqlStuff : IDisposable
    {
        private SQLiteConnection m_dbConnection;
        //DialogResult msgBoxResult = DialogResult.Ignore;
        //string myDirectory;
        public int beepFreq = 880;
        public int beepLength = 500;
        private SQLiteConnection dbConn;
    
        public void Dispose()
        {
            m_dbConnection?.Dispose();
            dbConn?.Dispose();
            Dispose(true);
	        GC.SuppressFinalize(this);
        }
    }
