       static class Executor
       {
          public static void Run(object obj)
          {
             var type = obj.GetType();
             var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
    
             var initMethods = new List<MethodInfo>();
             var cleanMethods = new List<MethodInfo>();
             foreach (var method in methods)
             {
                var initattrs = method.GetCustomAttributes(typeof(InitMethodAttribute));
                var cleanattrs = method.GetCustomAttributes(typeof(CleanupMethodAttribute));
    
                if (initattrs != null && initattrs.Count() > 0)
                   initMethods.Add(method);
                else if (cleanattrs != null && cleanattrs.Count() > 0)
                   cleanMethods.Add(method);
             }
    
             foreach (var method in methods)
             {
                var runattrs = method.GetCustomAttributes(typeof(RunMethodAttribute));
                if(runattrs != null)
                {
                   var runattr = runattrs.FirstOrDefault();
                   if(runattr != null)
                   {
                      foreach (var m in initMethods)
                         m.Invoke(obj, null);
    
                      method.Invoke(obj, null);
    
                      foreach (var m in cleanMethods)
                         m.Invoke(obj, null);
                   }
                }
             }
          }
       }
