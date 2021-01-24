	public class ThrowExpression<T>
	{
		public ThrowExpression(string message)
		{
	#line hidden
			throw new Exception(message);
	#line default
		}
        // never used, but makes the compiler happy:
		public static implicit operator T(ThrowExpression<T> obj)
		{
			return default(T);
		}
	}
