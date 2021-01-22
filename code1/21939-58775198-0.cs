    namespace Extensions
    {
    	public class Functions
    	{
    		public static T Difference<T>(object x1, object x2) where T : IConvertible
    		{
    			decimal d1 = decimal.Parse(x1.ToString());
    			decimal d2 = decimal.Parse(x2.ToString());
    
    			return (T)Convert.ChangeType(Math.Abs(d1-d2), typeof(T));
    		}
    	}
    }
