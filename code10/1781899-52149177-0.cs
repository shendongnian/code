    public class RangeCustomerAttribute : ValidationAttribute
    {
    	public long MaxValue { get; set; }
    	public long MinValue { get; set; }
    
    	public RangeCustomerAttribute(long minVal, long maxVal)
    	{
    		MaxValue = maxVal;
    		MinValue = minVal;
    	}
    	public override bool IsValid(object value)
    	{
    		int inputVal;
    		if (value == null)
    			return false;
    
    		if (int.TryParse(value.ToString(), out inputVal))
    		{
    
    			if (inputVal >= MinValue && inputVal <= MaxValue)
    				return (inputVal % 1) == 0;
    				
    		}
    		return false;
    	}
    }
