    class Program
    {
    	/// <summary> Number of subtypes reserved for each BookType. </summary>
    	private const byte BookTypeStep = 16;
    	/// <summary> Bitmask to use to extract BookType from a byte. </summary>
    	private const byte BookTypeExtractor = Byte.MaxValue - BookTypeStep + 1;
    	/// <summary> Bitmask to use to extract Book subtype from a byte. </summary>
    	private const byte BookSubTypeExtractor = BookTypeStep -1;
    	
    	public enum BookType : byte
    	{
    		Unknown = 0,
    		Novel = BookTypeStep * 1,
    		Journal = BookTypeStep * 2,
    		Reference = BookTypeStep * 3,
    		TextBook = BookTypeStep * 4,
    	}
    
    	static void Main(string[] args)
    	{
    		for(int i = 16; i < 80; i++)
    		{
    			Console.WriteLine("{0}\tof type {1} ({2}),\tsubtype nr {3}",
    				i,
    				i & BookTypeExtractor,
    				(BookType)(i & BookTypeExtractor),
    				i & BookSubTypeExtractor
    			);
    		}
    		Console.ReadLine();
    	}
    }
