	public abstract class BaseResponseBase
	{
		// Allows for non-generic access to the BaseResponse value if needed
		// Use a method rather than a property to prevent accidental serialization.
		public abstract object GetBaseValue();
	}
	public class BaseResponse<T> : BaseResponseBase
	{
		public override object GetBaseValue() { return Value; }
	
		public T Value { get; set; }
	}
