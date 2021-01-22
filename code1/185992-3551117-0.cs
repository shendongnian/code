    public class Sun : OuterSpace 
    {
      void SomeInitializationMethod()
      {
        Data = new SunData();
        Analysis = new SunAnalysis(); // etc
      }
        }
    
    // You could also make casting simpler with a generic method on the base
    public T GetData<T>()
    {
      if (Data is T)
      {
        return Data as T;
      }
      return null;
    };
