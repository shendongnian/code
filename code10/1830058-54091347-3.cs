    public static class WorkerExtensions
    {
      public static float Salary(this Worker worker)
      {
        switch(worker.WorkerType)
        {
          case WorkerType.Farmer:
            //calculate and return
    
          case WorkerType.Driver:
            //calculate and return
    
          default:
            return -1;
        }
      }
    }
