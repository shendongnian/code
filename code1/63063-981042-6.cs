    public class MyClass
    {
      // you don't need a constructor for this feature
    
      // no (public) setter so no-one can change the dictionary itself
      // it is set when creating a new instance of MyClass
      public IDictionary<int, string> TheDictionary { get; } = new Dictionary<int, string>();
    }
