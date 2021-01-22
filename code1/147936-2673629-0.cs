    public static class PatternExtensions
    {
    	public static ExpandCollapsePattern GetExpandCollapsePattern(this AutomationElement element)
    	{
    		return element.GetPattern<ExpandCollapsePattern>(ExpandCollapsePattern.Pattern);    
    	}
    
    	public static T GetPattern<T>(this AutomationElement element, AutomationPattern pattern) where T : class
    	{
    		object patternObject = null;
    		element.TryGetCurrentPattern(pattern, out patternObject);
    
    		return patternObject as T;
    	}
    }
