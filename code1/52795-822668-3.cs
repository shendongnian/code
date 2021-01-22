    class MyFileWatcher : System.IO.FileSystemWatcher, IDisposable
    {
       static void Main()
        {
        }
        new void Dispose()
        {
            try
            {
                // Do your cleanup here
            }
            finally
            {
                // ensure the base Dispose() is called
                base.Dispose();
            }
        }
        void IDisposable.Dispose()
        {
            // call MyFileWatcher.Dispose() implementation
            Dispose();
        }
    }
