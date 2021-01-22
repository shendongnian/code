    public class TheirClassWrapper : ITheirClass
    {
      private TheirClass instance = new TheirClass();
      
      public void DoSomething()
      {
        instance.DoSomething();
      }
    }
