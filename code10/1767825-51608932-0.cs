    public enum MyFruit
    {
    	[MyFunky(MyColor.Orange)]
    	Apple = 1,
    	[MyFunky(MyColor.Yellow)]
    	Orange = 2,
    	[MyFunky(MyColor.Red)]
    	Banana = 3
    }
    
    public enum MyColor
    {
    	Orange = 1,
    	Yellow = 2,
    	Red = 3
    }
    
    public static class MyExteions
    {
    	public static MyColor GetColor(this MyFruit fruit)
    	{
    		var type = fruit.GetType();
    		var memInfo = type.GetMember(fruit.ToString());
    		var attributes = memInfo[0].GetCustomAttributes(typeof (MyFunkyAttribute), false);
    		if (attributes.Length > 0)
    			return ((MyFunkyAttribute)attributes[0]).Color;
    		throw new InvalidOperationException("blah");
    	}
    }
    public class MyFunkyAttribute : Attribute
    {
    	public MyFunkyAttribute(MyColor color) { Color = color;}   
    	public MyColor Color { get; protected set; }
    }
