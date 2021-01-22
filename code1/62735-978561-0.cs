    public class Item
    {
    	public int Key { get; set; }
    	public int Value { get; set; }
    	public override string ToString()
    	{
    		return String.Format("{{{0}:{1}}}", Key, Value);
    	}
    }
