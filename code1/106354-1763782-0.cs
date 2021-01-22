    public static bool IsSimilarTo(this DateTime thisDateTime, DateTime otherDateTime, TimeSpan tolerance)
    {
    	DateTime allowedMinimum = thisDateTime.Subtract(tolerance);
    	DateTime allowedMaximum = thisDateTime.Add(tolerance);
    
    	if (otherDateTime < allowedMinimum || otherDateTime > allowedMaximum)
    	{
    		return false;
    	}
    
    	return true;
    }
