    public class MyClass
    {
      public MyClass()
      {
        TheDictionary = new Dictionary<int, string>();
      }
    
      // private setter so no-one can change the dictionary itself
      // so create it in the constructor
      public IDictionary<int, string> TheDictionary { get; private set; }
    }
