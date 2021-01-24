    public class MyInjectedClass
    {
         private readonly ILogger logger;
         public MyInjectedClass(ILogger logger)
         {
            this.logger = logger;
         }
    
         public void SomeMethod()
         {
            logger.Message();
         }
    }
