    static int counter = 0;
    		static void Main(string[] args)
    		{
    
    			Timer timer = new Timer(ResetCount, null, 0, 100000);
    			while (true)
    			{				
    				//Event simulation
    				if (Console.ReadKey().Key == ConsoleKey.Enter)
    				{
    					Console.WriteLine("Event triggerd"); ;
    					counter++;
    				}
    
    				if (counter > 3)
    				{
    					Console.WriteLine("Take a specific action");
    				}
    				else
    				{
    					Console.WriteLine("Take action B");
    				}
    
    				Thread.Sleep(1000);
    			}			
    		}
    
    		private static void ResetCount(object state)
    		{
    			counter = 0;
    		}
