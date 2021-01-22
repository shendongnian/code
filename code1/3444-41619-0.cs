     ThreadPool.QueueUserWorkItem(x => { 
        File.Open(fileName, FileMode.Open, FileAccess.Read);
        @event.WaitOne(); 
    });
    ThreadPool.QueueUserWorkItem(x => { 
        try
        {
            File.Delete(fileName);
        }
        catch (IOException e)
        {
            Debug.Write("File access denied");
        }
    });
