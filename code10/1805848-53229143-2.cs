    namespace AppWithLog4net
    {
        public class LocalStorageFileAppender : log4net.Appender.TextWriterAppender
        {
    
            private Stream m_stream;
    
            public LocalStorageFileAppender() : base() {  }
    
            protected override void PrepareWriter()
            {
                IAsyncOperation<Windows.Storage.StorageFile> task = Windows.Storage.ApplicationData.Current.LocalCacheFolder.CreateFileAsync("localStorage.log", 
                                                                                Windows.Storage.CreationCollisionOption.GenerateUniqueName);
                Windows.Storage.StorageFile file = task.GetAwaiter().GetResult();
                m_stream = file.OpenStreamForWriteAsync().Result;
                
                QuietWriter = new log4net.Util.QuietTextWriter(new StreamWriter(m_stream, Encoding.UTF8), ErrorHandler);
                WriteHeader();
            }
    
            protected override void Reset()
            {
                m_stream.Dispose();
                m_stream = null;
                base.Reset();
            }
        }
    }
