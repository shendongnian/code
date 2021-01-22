	static void Hook1()
	{
		someEvent += new EventHandler( Program_someEvent );
	}
	
	static void Hook2()
	{
		someEvent += Program_someEvent;
	}
