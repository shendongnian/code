    public class HttpFileDownloader : IFileDownloader
    {
        public virtual string Download(string url)
        {
            //Cut for brevity - downloads file here returns as string
            return html;
        }
    }
    
    public class HttpFileDownloaderWithRetries : HttpFileDownloader
    {
        private readonly int _retries;
        private readonly int _secondsBetweenRetries;
        public HttpFileDownloaderWithRetries(int retries, int secondsBetweenRetries)
        {
            _retries = retries;
            _secondsBetweenRetries = secondsBetweenRetries;
        }
        public override string Download(string url)
        {
            Exception lastException = null;
            for (int i = 0; i < _retries; i++)
            {
                try 
                { 
                    return base.Download(url); 
                }
                catch (Exception ex) 
                { 
                    lastException = ex; 
                }
                Utilities.WaitForXSeconds(_secondsBetweenRetries);
            }
            throw lastException;
        }
    }
