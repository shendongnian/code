    MakeADecision()
    {
        if (Properties.Settings.Default.MySetting)
        { 
            Console.Write(DoLocalStuff());
        }
        else
        {
            // Consider making MakeADecision async as well
            NewData = DoRemoteStuff().Result;
            Console.Write(NewData);
        }
    }
    
    async Task<string> DoRemoteStuff()
    {
        Task<string> task;
        using (OldDataTableAdapter)
        {
            OldDataTableAdapter.Insert(OldData);
            task = WaitForEvent(MyConnectionString);
        }
        return await task;
    }
    
    private async Task<string> WaitForEvent(string connectionString)
    {
        var taskCompletionSource = new TaskCompletionSource<string>();
        var revent = new FbRemoteEvent(connectionString);
        revent.RemoteEventCounts += (sender, e) =>
        {
            using (NewDataTableAdapter)
            {
                NewDataTableAdapter.Fill(NewDataDataTable);
                string newData = NewDataDataTable[0].MYCOLUMN;
                taskCompletionSource.SetResult(newData);
            }
            sender.Dispose();
        };
        revent.QueueEvents("MY_FB_EVENT");
    
        return await taskCompletionSource.Task;
    }
