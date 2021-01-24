    public interface IParent
    {
    	String World { get; }
    }
    
    public class Parent : IParent
    {
    	public virtual String World
        {
            get
            {
                return "Hello";
            }
        }
    }
    
    public class Children : Parent
    {
    	public override String World
    	{
    		get
    		{
    			return base.World + " World!";
    		}
    	}
    }
