    private void SetWorkerThreadToDoWork()
    {
      WorkerThread.Start();
    }
    
    private void MyWorkerThreadWork()
    {
      //This will be on the WorkerThread (called from WorkerThread.Start())
      DoWorkFunc();
      WorkComplete();
    }
    
    private void WorkComplete()
    {
      if(InvokeRequired == true)
      {
        //Do the invoke
      }
      else
      {
      //Check work done by worker thread
      //e.g. ServersSqlDataSourceEnumerator.Instance.GetDataSources();
      }
    }
