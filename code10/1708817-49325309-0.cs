    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class Authorization : AuthorizeAttribute
    { 
      ...
      dbRepo.LogAccessEntry(parameters);
      ...
    }
