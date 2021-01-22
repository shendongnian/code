    // Setup state as a parameter object containing a table and adapter to use to populate that table here
    
    void DoWork()
    {
        List<AutoResetEvent> signals = GetNumberOfWaitHandles(2);
    
        var params1 = new DataWorkerParameters
            {
                Command = GetCommand1();
                Table = new DataTable();
            }
    
        var params2 = new DataWorkerParameters
            {
                Command = GetCommand2();
                Table = new DataTable();
            }
    
        ThreadPool.QueueUserWorkItem(state => 
            {
                var input = (DataWorkerParameters)state;
                PopulateTable(input);
                input.AutoResetEvent.Set(); // You can use AutoResetEvent.WaitAll() in the caller to wait for all threads to complete
            },
            params1
        );
    
        ThreadPool.QueueUserWorkItem(state => 
            {
                var input = (DataWorkerParameters)state;
                PopulateTable(input);
                input.AutoResetEvent.Set(); // You can use AutoResetEvent.WaitAll() in the caller to wait for all threads to complete
            },
            params2
        );
        
        WaitHandle.WaitAll(signals.ToArray());
    }
    
    
    void PopulateTable(DataWorkerParameters parameters)
    {
        input.Command.ExecuteReader();
        input.Table.Load(input.Command);
    }
