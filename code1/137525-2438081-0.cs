    public class MyWebClient : WebClient
    {
        delegate byte[] DownloadDataInternal(Uri address, out WebRequest request);
        DownloadDataInternal downloadDataInternal;
    
        public MyWebClient()
        {
            downloadDataInternal = (DownloadDataInternal)Delegate.CreateDelegate(
                typeof(DownloadDataInternal),
                this,
                typeof(WebClient).GetMethod(
                    "DownloadDataInternal",
                    BindingFlags.NonPublic | BindingFlags.Instance));
        }
    
        public byte[] DownloadDataInternal(Uri address, out WebRequest request)
        {
            return downloadDataInternal(address, out request);
        }
    }
