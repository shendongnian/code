    namespace Examples {
        public static class BeginOpenReadExample {
            static ManualResetEvent m_reset = new ManualResetEvent(false);
    
            public static void BeginOpenRead() {
                // The using statement here is OK _only_ because m_reset.WaitOne()
                // causes the code to block until the async process finishes, otherwise
                // the connection object would be disposed early. In practice, you
                // typically would not wrap the following code with a using statement.
                using (FtpClient conn = new FtpClient()) {
                    m_reset.Reset();
                    
                    conn.Host = "localhost";
                    conn.Credentials = new NetworkCredential("ftptest", "ftptest");
                    conn.BeginOpenRead("/path/to/file",
                        new AsyncCallback(BeginOpenReadCallback), conn);
    
                    m_reset.WaitOne();
                    conn.Disconnect();
                }
            }
    
            static void BeginOpenReadCallback(IAsyncResult ar) {
                FtpClient conn = ar.AsyncState as FtpClient;
    
                try {
                    if (conn == null)
                        throw new InvalidOperationException("The FtpControlConnection object is null!");
    
                    using (Stream istream = conn.EndOpenRead(ar)) {
                        byte[] buf = new byte[8192];
                        ...
