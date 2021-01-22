    public class ThreadMarker:IDisposable
    {
      [ThreadStatic]
      private static string __Name;
 
      static Dictionary<int,string> ThreadNames=new Dictionary<int,string>();
      public static Name{get{return __Name;}}
    
      public ThreadMarker(string name)
      {
        lock(ThreadNames){
          ThreadNames[Thread.CurrentThread.ManagedThreadId]=name;
        }
        __Name=name; 
      }
    
      public void Dispose()
      {
        ThreadNames.Remove(Thread.CurrentThread.ManagedThreadId);
        __Name="Unowned";
      } 
    }
    
