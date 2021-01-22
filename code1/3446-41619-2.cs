     ThreadPool.QueueUserWorkItem(x => { 
        File.Open(fileName, FileMode.Open);
        event1.Set(); // Start 2nd tread;
        event2.WaitOne(); // Blocking the file;
    });
    ThreadPool.QueueUserWorkItem(x => { 
        try
        {
            event1.WaitOne(); // Waiting until 1st thread open file
            File.Delete(fileName); // Simulating conflict
        }
        catch (IOException e)
        {
            Debug.Write("File access denied");
        }
    });
