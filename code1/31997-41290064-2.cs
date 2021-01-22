    public class Meters : ValueObject<Meters>
    {
    	...
    
    	protected decimal DistanceInMeters { get; private set; }
    
    	...
    
    	protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
    	{
    		return new List<Object> { DistanceInMeters };
    	}
    }
