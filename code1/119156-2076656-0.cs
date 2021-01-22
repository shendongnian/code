    class Downloader {
    
        public void Download(string url, string localPath) {
            if (localPath == null) {
                localPath = Environment.CurrentDirectory;
            }
            // implement blocking download code
        }
    
        public void Download(string url) {
            Download(url, null);
        }
    
        public void DownloadAsync(string url, string localPath) {
            // call the sync version using your favorite
            // threading api (threadpool, tasks, delegate.begininvoke, etc)
            ThreadPool.QueueUserWorkItem( state => {
                Download(url, localPath);
                SynchronizationContext.Current.Post( OnDownloadCompleted, null );
            });
        }
    
        public void DownloadAsync(string url) {
            DownloadAsync(url, null);
        }
    
        private void OnDownloadCompleted(object state) {
            var handler = DownloadCompleted;
            if (handler != null) {
                handler(this, EventArgs.Empty);
            }
        }
    
        public event EventHandler DownloadCompleted;
    
    }
