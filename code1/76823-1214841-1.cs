    class Program
    {
    	static void Main(string[] args)
    	{
    		ChrisTime t = new ChrisTime();
    		Console.WriteLine(t);
    
    		DateTime time = new DateTime();
    		Console.WriteLine(time);
    
    		Console.Read();
    	}
    }
    public struct ChrisTime
    {
    	private int _length;
    
    	public int Length
    	{
    		get
    		{
    			return _length;
    		}
    		set
    		{
    			_length = value;
    		}
    	}
    
    	public override string ToString()
    	{
    		return Length.ToString();
    	}
    
    }
