    public void GenerateDocs()
    {
        List<Task> tasks = new List<Task>();
        lock (_lockForLog)
        {
            _swForLogging.Start();
        }
        _processing = true;
        for (i = 0; i < 50; i ++)
        {
            tasks.Add(Task.Run(() => DoWork());
        }
        //task which records progress
        //ONLY runs if not many tasks are created above
        Task.Run(() => RecordProgress());
        Task.WaitAll(tasks.ToArray());
        
        lock (_lockForLog)
        {
            _swForLogging.Stop();
        }
    }
    public void DoWork(){
        //do work
        lock (_lockForLog)
        {
            if (_swForLogging.ElapsedMilliseconds > 3000)
            {
                Console.WriteLine("Generated " + _docsGenerated + " documents.");
                _swForLogging.Restart();
            }
        }
    }
