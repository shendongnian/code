    public void Log(string entry)
    {
        _logMutex.WaitOne();
        _logQueue.Enqueue(entry);
        _logMutex.ReleaseMutex();
    }
    private void Write()
    {
        ...
        _logMutex.WaitOne();
        string entry = _logQueue.Dequeue();
        _logMutex.ReleaseMutex();
        _filestream.WriteLine(entry);
        ...
    }
