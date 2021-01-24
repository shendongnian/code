    public void SomethingExecuter(IEnumerable<string> FileNames, Action<string> Something)
    {
        foreach (string FileName in FileNames)
        {
            Something(FileName);
        }
    }
    public SomethingOne(string FileName)
    {
        // todo - copy the file with name FileName to some web server
    }
    public SomethingOne(string FileName)
    {
        // todo - delete the file with name FileName
    }
