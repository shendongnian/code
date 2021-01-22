    public static void MustBeInRange<T>(this T x, T minimum, T maximum, string paramName)
    where T : IComparable<T>
    {
    	bool underMinimum = (x.CompareTo(minimum) < 0);
    	bool overMaximum = (x.CompareTo(maximum) > 0);
    	if (underMinimum || overMaximum)
    	{
    		string message = string.Format(
    			System.Globalization.CultureInfo.InvariantCulture,
    			"Value outside of [{0},{1}] not allowed/expected",
    			minimum, maximum
    		);
    		if (string.IsNullOrEmpty(paramName))
    		{
    			Exception noInner = null;
    			throw new ArgumentOutOfRangeException(message, noInner);
    		}
    		else
    		{
    			throw new ArgumentOutOfRangeException(paramName, x, message);
    		}
    	}
    }
    public static void MustBeInRange<T>(this T x, T minimum, T maximum)
    where T : IComparable<T> { x.MustBeInRange(minimum, maximum, null); }
    
