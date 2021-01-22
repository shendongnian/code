    // fsw_ is the FileSystemWatcher instance used by my application.
    private void OnDirectoryChanged(...)
    {
       try
       {
          fsw_.EnableRaisingEvents = false;
          /* do my stuff once asynchronously */
       }
       finally
       {
          fsw_.EnableRaisingEvents = true;
       }
    }
