    using System;
    using System.Linq;
    
    public class Program
    {
    	public class O
    	{
    		public int CustomerId;
    		public int OrderId;
    		public O(int c,int o) 
    		{
    			CustomerId = c; 
    		    OrderId = o;
    		}
    		public override string ToString() 
            {
                return string.Format("(C_ID: {0}, O_ID:{1})",CustomerId, OrderId);
            }
    	}
    	
    		
    	public static void Main()
    	{
    		var data = new O[]{ new O(1,1),new O(2,1),new O(3,1),new O(1,2)};
    		
            var duplicateRow = (from o in data
                                group o by new { o.CustomerId } into results
                                select results.Reverse().Take(1) // reverse and then take 1
                               ).SelectMany(a => a);
    
            foreach( var o in duplicateRow)
    				Console.WriteLine(o);
    				
    		Console.ReadLine();
    	}
    }
