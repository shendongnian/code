    public class WorkObject
    {
       public PercentComplete { get; private set; }
       public IsFinished { get; private set; }
       public void DoSomeWork()
       {
          // work done here
          this.PercentComplete = 50;
          
          // some more work done here
          this.PercentComplete = 100;
          this.IsFinished = true;
       }
    }
