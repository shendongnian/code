    class Program
    {
    	static void Main(string[] args)
    	{
    		int limit = 100;
    		List<int> prime = new List<int>();
    		prime.Add(2);
    		for (int number = 3; number <= limit; number = number + 1)
    		{
    			bool isPrime = true;
    			
    			foreach (int prime2 in prime)
    			{
    				if (number % prime2 == 0)
    				{
    					isPrime = false;
    					break;
    				}
    			}
    
    			if (isPrime)
    			{
    				Console.WriteLine(number + " is a prime");
    				prime.Add(number);
    			}
    			else
                {
    				Console.WriteLine(number + " is not a prime");
    			}
    		}
    	}
    }
