    public class ThreadMarker:IDisposable
    {
      [ThreadStatic]
      public static string Name;
    
      public ThreadMarker(string name)
      {
        Name=name; 
      }
    
      public void Dispose()
      {
        Name="Unowned";
      } 
    }
    
    // usage
    
    ThreadPool.QueueUserWorkItem(state=>{
      using new TreadMarker("Foo"){
        doStuff();
      }
    });
