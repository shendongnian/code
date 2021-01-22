    public sealed class Nothing
    { 
      public static Nothing Value = new Nothing(); 
      private Nothing() {}
    }
    
    Dictionary<object, string> dict = new Dictionary<object, string>();
    dict.add(Nothing.Value, "Nothing");
    dict.add(1, "One");
