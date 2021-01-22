    private List<IStopable> WorkerClasses = new List< IStopable > ()
  
    public Bool StopRequest{
        get
        {
              return _stopRequest;
        }
        set 
        {
            _stopReqest = value;
            foreach (var child in WorkerClasses)
                child.StopRequest = value;
        }
    }
