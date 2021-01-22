    public class SomeType
    {
      public static implicit operator OtherType(SomeType s) 
      { 
        return new OtherType(); 
      }
    }
    public class OtherType { }
    
    object x = new SomeType();
    OtherType y = (OtherType)x; // will fail at runtime
