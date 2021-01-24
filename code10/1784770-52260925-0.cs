    ActionBlock<string> _block;
    void Main()
    {
        ...
        var options= new ExecutionDataflowBlockOptions
         {
            MaxDegreeOfParallelism = 4
         };
        _block=new ActionBlock<string>(path=>MyPathProcessingFunction(path), options);
       //Configure the FSW as before
    }
    private void fsw_Created(object sender, FileSystemEventArgs e)
    {
        _block.Post(e.FullPath);
    }
