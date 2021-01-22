    DateTime lastRead = DateTime.MinValue;
    void OnChanged(object source, FileSystemEventArgs a)
    {
        DateTime lastWriteTime = File.GetLastWriteTime(uri);
        if (lastWriteTime != lastRead)
        {
            doStuff();
            lastRead = lastWriteTime;
        }
        // else discard the (duplicated) OnChanged event
    }
