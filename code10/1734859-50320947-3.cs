    public interface IHasValue
    {
        object GetValue(); // A method rather than a property to ensure the non-generic value is never serialized directly.
    }
    public class ValueObject<T> : IHasValue
    {
    	public T Value { get; }
    	public ValueObject(T value) => Value = value;
    	
        // various other equality members etc...
        #region IHasValue Members
        object IHasValue.GetValue() => Value;
        #endregion
    }
