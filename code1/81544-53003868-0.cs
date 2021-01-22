    var distinctValues
        = myCustomerList.Distinct(new LambdaEqualityComparer<OurType>((c1, c2) => c1.CustomerId == c2.CustomerId));
    public class LambdaEqualityComparer<T> : IEqualityComparer<T>
    	{
    		public LambdaEqualityComparer(Func<T, T, bool> equalsFunction)
    		{
    			_equalsFunction = equalsFunction;
    		}
    
    		public bool Equals(T x, T y)
    		{
    			return _equalsFunction(x, y);
    		}
    
    		public int GetHashCode(T obj)
    		{
    			return obj.GetHashCode();
    		}
    
    		private readonly Func<T, T, bool> _equalsFunction;
    	}
