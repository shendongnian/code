    class Program
    {
    	static void Main(string[] args)
    	{
    		bool playAgain = true;
    
    		while (playAgain)
    		{
    			decimal mark = 0, lowMark = -1, highMark = -1, sum = 0, average = 0; 
    			int count = 0;                
    
    			do
    			{
    				Console.Write("Please enter a mark for the student or enter 999 to quit: ");
    
    				if (!decimal.TryParse(Console.ReadLine(), out mark) || 
    					(mark < 0 || mark > 100 || (mark > 0 && mark < 1)))
    				{
    					Console.WriteLine("Invalid input value.");
    					continue;
    				}
    				else
    				{
    					mark = mark / (decimal)100;
    					sum += mark;
    					count++;
    					if (lowMark < 0 || mark < lowMark)
    					{
    						lowMark = mark;
    					}
    					if (mark > highMark)
    					{
    						highMark = mark;
    					}
    				}
    			} while (mark != 999);
    
    			average = count == 0 ? 0 : sum / count;
    			lowMark = lowMark < 0 ? 0 : lowMark;
    			highMark = highMark < 0 ? 0 : highMark;
    
    			Console.WriteLine("\nThe class average was {0}", 
    				average.ToString("P1", CultureInfo.InvariantCulture));
    			Console.WriteLine("The highest mark was {0} and the lowest mark was {1}", 
    				highMark.ToString("P1", CultureInfo.InvariantCulture), 
    				lowMark.ToString("P1", CultureInfo.InvariantCulture));
    			Console.WriteLine("\nWould you like to start again?: Y/N");
    			playAgain = Console.ReadKey().Key == ConsoleKey.Y;
    			Console.WriteLine();
    		}
    	}
    }
