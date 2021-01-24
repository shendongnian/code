    public class MyObject
    {
      private ValueEnum SomeValue {get; set;}
      private int? SomeOtherValue {get; set;}
    
      public void Update(ValueEnum someValue, int? someOtherValue = null)
      {
        if ( (someOtherValue.HasValue && someValue != ValueEnum.HasOtherValue)
          || (!someOtherValue.HasValue && someValue == ValueEnum.HasOtherValue))
          throw new ArgumentException("Invalid value combination.");
    
        SomeValue = someValue;
        SomeOtherValue = someOtherValue;
      }
    }
