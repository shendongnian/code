    public void SomethingExecuter(IEnumerable<string> FileNames, Action<string> Something)
    {
        foreach (string FileName in FileNames)
        {
            Something(FileName);
        }
    }
    public void SomethingOne(string FileName)
    {
        // todo - copy the file with name FileName to some web server
    }
    public void SomethingTwo(string FileName)
    {
        // todo - delete the file with name FileName
    }
