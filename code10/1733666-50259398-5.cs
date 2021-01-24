	public interface ConditionBase
	{
		Field Field { get; set; }
		ConditionOperator ConditionOperator { get; set; }
		object FieldValue { get; }
	}
	public class Condition<T> : ConditionBase
	{
      /* I only included the added code in this type */
	  public object FieldValue
	  {
		  get { return (object) this.Value; }
	  }
	}
	
