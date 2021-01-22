    public class MyClass
    {
      [Import(ILogger)]
      public ILogger logger;
    
      public MyClass()
      {
      }
    
      public void DoSomething()
      {
        logger.Info("Hello World!");
      }
    }
