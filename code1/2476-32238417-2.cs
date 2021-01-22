     public class Caller 
     {
         public static void Call() 
         {
             ITraced traced = (ITraced)new MethodLogInterceptor(typeof(ITraced), new Traced()).GetTransparantProxy();
             traced.Method1();
             traced.Method2(); 
         }
     }
