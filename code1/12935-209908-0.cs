    public interface IDoFunctions
    {
        void DoSomething();
    }
    
    public static class FunctionFactory
    {
      public static IDoFunctions GetFunctionInterface()
      {
         if (HttpContext.Current != null)
         {
            return new WebFunctionInterface();
         }
         else
         {
            return new NonWebFunctionInterface();
         }
       }
    }
    public IDoFunctions WebFunctionInterface
    {
        public void DoSomething()
        {
            ... do something the web way ...
        }
    }
    public IDoFunctions NonWebFunctionInterface
    {
        public void DoSomething()
        {
            ... do something the non-web way ...
        }
    }
