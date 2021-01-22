    class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.WriteLine((int)Number.three); //Output=3
    
    			Console.WriteLine((Number)3);// Outout three
    			Console.Read();
    		}
    
    		public enum Number 
    		{
    			Zero = 0,
    			One = 1,
    			Two = 2,
    			three = 3			
    		}
    	}
