    public class ValueHolder
    {
      object Value;
    }
    
    public class Main
    {
      private ValueHolder value1 = new ValueHolder();
      private ValueHolder value2 = new ValueHolder();
    
      public Value1 { get { return value1.Value; } set { value1.Value = value; } }
      public Value2 { get { return value2.Value; } set { value2.Value = value; } }
    
      public ValueHolder CalculateOne(ValueHolder holder ...)
      {
        // Whatever you need to calculate.
      }
    
      public CalculateBoth()
      {
        var answer1 = CalculateOne(value1);
        var answer2 = CalculateOne(value2);
        ...
      }
    }
