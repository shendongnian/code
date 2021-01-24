    public class WI : ICloneable
    {
    	public int age1 { get; set; }
    	public object Clone()
    	{
    		return new WI() { age1 = this.age1 };
    	}
    }
