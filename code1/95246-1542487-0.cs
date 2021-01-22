    mClients.Where(c => !c.IsDisconnected && !c.ReadingInProgress).ToList().ForEach(c=> {
        if (!c.SetReadingInProgress())  {
            ThreadPool.QueueUserWorkItem(c.ReadData);                        
        }
    });
