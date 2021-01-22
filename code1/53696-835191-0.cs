    public void DoSomething(ProcessingMethod method)
    {
      method.Process();
    }
    
    public abstract class ProcessingMethod
    {
      public abstract void Process();
    }
    
    public class Sequental : ProcessingMethod
    {
      public override void Process()
      {
        // do something sequential
      }
    }
    public class Random : ProcessingMethod
    {
      public override void Process()
      {
        // do something random
      }
    }
