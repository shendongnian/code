    private Dictionary<Guid, WorkObject> _workList = 
       new Dictionary<Guid, WorkObject>();
    private bool _finished = false;
    
    public Guid QueueAsyncWork(WorkObject workObject)
    {
        Guid guid = Guid.NewGuid();
        // simplified for the sake of example
        _workList.Add(guid, workObject);
        return guid;
    }
    private void WorkThread()
    {
        // simplified for the sake of example
        while (!_finished)
        {
            foreach (WorkObject workObject in _workList)
            {
                if (!workObject.IsFinished)
                {
                    workObject.DoSomeWork();
                }
            }
            Thread.Sleep(1000);
        }
    }
    
    // an example of getting the WorkObject's property
    public int GetPercentComplete(Guid guid)
    {
       WorkObject workObject = null;
       if (!_workList.TryGetValue(guid, out workObject)
          throw new Exception("Unable to find Guid");
       return workObject.PercentComplete;
    }
