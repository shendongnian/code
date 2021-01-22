    public class AsyncHelper {
     delegate void DynamicInvokeShimProc(Delegate d, object[] args); 
     static DynamicInvokeShimProc dynamicInvokeShim = new 
       DynamicInvokeShimProc(DynamicInvokeShim); 
     static AsyncCallback dynamicInvokeDone = new 
       AsyncCallback(DynamicInvokeDone); 
      public static void FireAndForget(Delegate d, params object[] args) { 
        dynamicInvokeShim.BeginInvoke(d, args, dynamicInvokeDone, null); 
      } 
      static void DynamicInvokeShim(Delegate d, object[] args) { 
       DynamicInvoke(args); 
      } 
      static void DynamicInvokeDone(IAsyncResult ar) { 
        dynamicInvokeShim.EndInvoke(ar); 
     } 
    }
