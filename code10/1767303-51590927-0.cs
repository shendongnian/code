    public class Program
    {
    	public static void Main()
    	{
    		Bus.Init(0);
            Bus bus1 = new Bus(71);
    		Console.WriteLine(Bus.FirstBusNumber); // it prints 71 as your expected
    	}
    }
    
    public class Bus
    {
        public static int FirstBusNumber;
    
        public static void Init(int firstBusNumber)
        {
            FirstBusNumber = firstBusNumber;
        }
    	
    	public Bus(int routeNum)
    	{
    		if(FirstBusNumber<1)
    		   FirstBusNumber = routeNum;
    	}
    }
