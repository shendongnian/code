    public class ThreadMarker:IDisposable
    {
      [ThreadStatic]
      private static string __Name;
      public static Name{get{return __Name;}}
    
      public ThreadMarker(string name)
      {
        __Name=name; 
      }
    
      public void Dispose()
      {
        __Name="Unowned";
      } 
    }
    
    // usage
    void doStuff(){
      Log("Stuf done in thread {0} ",ThreadMarker.Name);
    }    
    ThreadPool.QueueUserWorkItem(state=>{
      using new TreadMarker("Foo"){
        
        doStuff();
  
      }
    });
