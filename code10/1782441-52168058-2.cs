    public abstract class TheBaseClass
    {
    
    	public enum MyEnum {a,b }
    
    	public abstract string GetName(int value);
    }
    
    public class SpecializedClass : TheBaseClass
    {
    
    	public new enum MyEnum {c,d }
    
    	public override string GetName(int value)
    	{
    		return ((MyEnum)value).ToString();
    	}
    }
