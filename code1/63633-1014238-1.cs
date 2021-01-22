    Queue<string> _filesToProcess = new Queue<string>();
    Queue<string> _results = new Queue<string>();
    Thread _fileProcessingThread = new Thread( ProcessFiles );
    Thread _databaseUpdatingThread = new Thread( UpdateDatabase );
    bool _finished = false;
    static void Main()
    {
        foreach( string fileName in GetFileNamesToProcess() )
        {
           _filesToProcess.Enqueue( fileName );
        }
        _fileProcessingThread.Start();
        _databaseUpdatingThread.Start();
        // if we want to wait until they're both finished
        _fileProcessingThread.Join();
        _databaseUpdatingThread.Join();
        Console.WriteLine( "Done" );
    }
    void ProcessFiles()
    {
       bool filesLeft = true;
       lock( _filesToProcess ){ filesLeft = _filesToProcess.Count() > 0; }
       while( filesLeft )
       {
          string fileToProcess;
          lock( _filesToProcess ){ fileToProcess = _filesToProcess.Dequeue(); }
          string resultAsString = ProcessFileAndGetResult( fileToProcess );
          lock( _results ){ _results.Enqueue( resultAsString ); }
          Thread.Sleep(1); // prevent the CPU from being 100%
          lock( _filesToProcess ){ filesLeft = _filesToProcess.Count() > 0; }
       }
       _finished = true;
    }
    void UpdateDatabase()
    {
       bool pendingResults = false;
       lock( _results ){ pendingResults = _results.Count() > 0; }
       while( !_finished || pendingResults )
       {
          if( pendingResults )
          {
             string resultsAsString;
             lock( _results ){ resultsAsString = _results.Dequeue(); }
             InsertIntoDatabase( resultsAsString ); // implement this however
          }
          Thread.Sleep( 1 ); // prevents the CPU usage from being 100%
          lock( _results ){ pendingResults = _results.Count() > 0; }
       }
    }
