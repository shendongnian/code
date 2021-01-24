    public static void Main(string[] args)
    {
    	const int MinHeight = 10;
    	const int MinWidth = 10;
    	Task.Factory.StartNew(() =>
    	{
    		while (true)
    		{
    			if (Console.WindowHeight > MinHeight || Console.WindowWidth > MinWidth)
    			{
    				Console.SetWindowSize(MinWidth, MinHeight);
    			}
    		}
    	});
    	//	Do some work here
    	Console.ReadKey();
    }
