	public interface IValueHolder{
	   object value { get; }
	}
	public class ValueHolder<TValue> : IValueHolder
	{
		// as before
		object IValueHolder.value => (object)value;
	}
