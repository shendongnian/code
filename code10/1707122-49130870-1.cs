    public enum MyEnum
	{
		North  = 0, //old
		Top    = 0, //new
		South  = 1, //old
		Bottom = 1  //new
	}
	
	public static void Main()
	{
        // Parse "old" from XML config (simulated)
		MyEnum test = (MyEnum)Enum.Parse(typeof(MyEnum),"North");
        //          = MyEnum.North
		
		switch(test)
		{
			case MyEnum.Top:
    			Console.WriteLine("NORTH");
	    		break;
			case MyEnum.Bottom:
		    	Console.WriteLine("SOUTH");
			    break;
			default:
			    Console.WriteLine("Unsupported!");
    			break;
			
		}
	}
