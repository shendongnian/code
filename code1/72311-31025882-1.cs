    static void Main(string[] args)
    		{
    			int num = 3500;
    			long start = System.Diagnostics.Stopwatch.GetTimestamp();
    			for (int i = 0; i < 2000000; i++)
    				if (num != HexStringToInt(IntToHexString(num, 3)))
    					Console.WriteLine(num + " = " + HexStringToInt(IntToHexString(num, 3)));
    			long end = System.Diagnostics.Stopwatch.GetTimestamp();
    			Console.WriteLine(((double)end - (double)start)/(double)System.Diagnostics.Stopwatch.Frequency);
    
    			for (int i = 0; i < 2000000; i++)
    				if (num != Convert.ToInt32(num.ToString("X3"), 16))
    					Console.WriteLine(i);
    			end = System.Diagnostics.Stopwatch.GetTimestamp();
    			Console.WriteLine(((double)end - (double)start)/(double)System.Diagnostics.Stopwatch.Frequency);
    			Console.ReadLine();	
    		}
