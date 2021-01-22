    public class WorkerUsingMethod
    {
       // Explicitly obvious that calculation is being done here
       public int CalculateResult()
       { 
          return ExpensiveLongRunningCalculation();
       }
    }
    public class WorkerUsingProperty
    {
       // Not at all obvious.  Looks like it may just be returning a cached result.
       public int Result
       {
           get { return ExpensiveLongRunningCalculation(); }
       }
    }
