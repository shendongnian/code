    [Serializable]
    public class LogAttribute : OnMethodInvocationAspect
    {
       public override void OnInvocation(MethodInvocationEventArgs eventArgs)
       {
          try
          {
             eventArgs.Proceed();
          }
          catch(Exception ex)
          {
             // log exception here
          }
       }
    }
