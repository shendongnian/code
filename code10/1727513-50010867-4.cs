	static public class EqualityComparerExtensionMethods
	{
		public class GeneralComparer<TItem> : IEqualityComparer<TItem> 
		{
			protected readonly Func<TItem,object> _propertyFunction;
			
			public GeneralComparer(Func<TItem,object> propertyFunction)
			{
				_propertyFunction = propertyFunction;
			}
			public bool Equals(TItem a, TItem b)
			{
				return _propertyFunction(a).Equals(_propertyFunction(b));
			}
			
			public int GetHashCode(TItem f)
			{
				return _propertyFunction(f).GetHashCode();
			}
										 
		}
	
		static public GeneralComparer<TItem> GetEqualityComparer<TItem>(this IEnumerable<TItem> This, Func<TItem,object> propertyFunction)
		{
			return new GeneralComparer<TItem>(propertyFunction);
		}
	}
