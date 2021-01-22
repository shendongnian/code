public enum ConditionOperatorsString { None, Like, Equal }
public enum ConditionOperatorsDate { None, Equal, BeforeThan, AfterThan }
public class Condition&lt;T, TEnum&gt;
{
  public T Value { get; set; }
  public TEnum Operator { get; set; }
  public Condition(T Value, TEnum Operator)
  {
    this.Value = Value;
    this.Operator = Operator;
  }
}
