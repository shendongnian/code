    public class ReadOnlyState<T>
    {
      public ReadOnlyState(T t) { this.t = t; }
    
      readonly object theLock = new object();
      readonly T t;
      public delegate void ActionRef(in T t);
      public void Lock(ActionRef action) { lock (theLock) action(in t); }
    }
    
    var ros = new ReadOnlyState<int>(5);
    ros.Lock((in int v) => {
       v.f();
       v=2; // does not compile
    });
