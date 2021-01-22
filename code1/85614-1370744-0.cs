    public abstract class ConditionBase<T, E>
    {
      public T Value { get; set; }
      public E Operator { get; set; }
      protected ConditionBase(T Value, E Operator)
      {
        this.Value = Value;
        this.Operator = Operator;
      }
    }
    public enum ConditionOperatorsString { None, Like, Equal }
    public class ConditionString : ConditionBase<string, ConditionOperatorsString>
    {
      public ConditionString(String Value, ConditionOperatorsString Operator) : base(Value, Operator) { }
    }
    public enum ConditionOperatorsDate { None, Like, BeforeThan, AfterThan }
    public class ConditionDate : ConditionBase<DateTime?, ConditionOperatorsDate>
    {
      public ConditionDate(DateTime? Value, ConditionOperatorsDate Operator) : base(Value, Operator) { }
    }
