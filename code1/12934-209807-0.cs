    public class SomeClass {
      public bool  RunningUnderAspNet    { get; private set; }
      
      public SomeClass()
        //
        // constructor
        //
      {
        try {
          RunningUnderAspNet = null != HttpContext.Current;
        }
        catch {
          RunningUnderAspNet = false;
        }
      }
    }
