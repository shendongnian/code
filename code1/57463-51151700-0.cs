    public static class ExtensionMethods
    {
    	/// <summary>
    	/// Returns true if string could represent a valid number, including decimals and local culture symbols
    	/// </summary>
    	public static bool IsNumeric(this string s)
    	{
    		decimal d;
    		return decimal.TryParse(s, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.CurrentCulture, out d);
    	}
    
    	/// <summary>
    	/// Returns true only if string is wholy comprised of numerical digits
    	/// </summary>
    	public static bool IsNumbersOnly(this string s)
    	{
    		if (s == null || s == string.Empty)
    			return false;
    
    		foreach (char c in s)
    		{
    			if (c < '0' || c > '9') // Avoid using .IsDigit or .IsNumeric as they will return true for other characters
    				return false;
    		}
    
    		return true;
    	}
    }
