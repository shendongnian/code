     public static int Method1(string mystring)
           {
               return 1;
           }
    
            public static int Method2(string mystring)
         {
           return 2;
         }
         public static object InvokeMethod(Delegate method, params object[] args)
         {
             return method.DynamicInvoke(args);
         }
