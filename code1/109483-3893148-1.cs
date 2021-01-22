    public class MyCallHandler : ICallHandler, IDisposable
    {
        public IMethodReturn Invoke(IMethodInvocation input, 
            GetNextHandlerDelegate getNext)
        {
            var methodReturn = getNext().Invoke(input, getNext);
            // log everything...
            LogMethodCall(input, methodReturn);
            // log exception if there is one...
            if (methodReturn.Exception != null)
            {
                LogException(methodReturn);
            }
         
            return methodReturn;
        }
    }
