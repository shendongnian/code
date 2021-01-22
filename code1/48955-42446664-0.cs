    // Base Class for balls 
    public class BaseBall
    {
    	// keep synced with subclasses!
    	public enum Sizes
    	{
    		Small,
    		Medium,
    		Large
    	}
    }
    
    public class VolleyBall : BaseBall
    {
    	// keep synced with base class!
    	public new enum Sizes
    	{
    		Small = BaseBall.Sizes.Small,
    		Medium = BaseBall.Sizes.Medium,
    		Large = BaseBall.Sizes.Large,
    		SmallMedium,
    		MediumLarge,
    		Ginormous
    	}
    }
