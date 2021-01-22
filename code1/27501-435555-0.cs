    public static void MustBeInRange<T>(this T x, T minimum, T maximum, string paramName)
    where T : IComparable<T>
    {
    	bool underMinimum = (x.CompareTo(minimum) < 0);
    	bool overMaximum = (x.CompareTo(maximum) > 0);
    	if (underMinimum || overMaximum)
    	{
    		const string RANGE_ERROR = "Value outside of [{0},{1}] not allowed/expected";
    		string message = string.Format(
    			System.Globalization.CultureInfo.InvariantCulture,
    			RANGE_ERROR, minimum, maximum
    		);
    		ArgumentOutOfRangeException outOfRange;
    		if (string.IsNullOrEmpty(paramName))
    		{
    			Exception noInner = null;
    			outOfRange = new ArgumentOutOfRangeException(message, noInner);
    		}
    		else
    		{
    			outOfRange = new ArgumentOutOfRangeException(paramName, x, message);
    		}
    		throw outOfRange;
    	}
    }
    public static void MustBeInRange<T>(this T x, T minimum, T maximum)
    where T : IComparable<T> { x.MustBeInRange(minimum, maximum, null); }
    
