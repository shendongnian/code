    // The Collection of values to be enumerated
	public class DocketEnum : EnumarationCollection<DocketType, int, string>
	{
            // Values are fields on a statically instanced version of this class
	    public DocketType Withdrawal = new DocketType(2, "Withdrawal");
	    public DocketType Installation = new DocketType(3, "Installation");
	
	    // The publicly accessible static enumeration 
	    public static DocketEnum Values = new DocketEnum();
	}
	
	// The actual value class
	public class DocketType : EnumerationValue<DocketType, int, string>
	{
            // Call through to the helper base constructor
	    public DocketType(int docketTypeId, string description) 
	        : base(docketTypeId, description) { }
	}
		
	// Base class for the enumeration
	public abstract class EnumarationCollection<TType, X, Y>
		where TType : EnumerationValue<TType, X, Y> 
	{
                // Resolve looks at the static Dictionary in the base helpers class
		public TType Resolve(X value)
		{
			return Cache[value] as TType;
		}
		
		public static Dictionary<X, EnumerationValue<TType, X, Y> > Cache = new Dictionary<X, EnumerationValue<TType, X, Y>>();
	}
	
	// Base class for the value
	public abstract class EnumerationValue<TType, X, Y> 
		where TType : EnumerationValue<TType, X, Y> 
	{        
            // helper constructer talks directly the the base helper class for the Enumeration
	    protected EnumerationValue(X value, Y displayName)
	    {
	        EnumarationCollection<TType, X,Y >.Cache.Add(value, this as TType);
	    }
	}
		
	
	
	class MainClass
	{
		public static void Main (string[] args)
		{
                        // You can immediately resolve to the enumeration
			Console.WriteLine(DocketEnum.Values.Resolve(2).ToString());
		}
	}
