    using System;
    using System.Text.RegularExpressions;
    					
    public class Program
    {
    	public static void Main()
    	{
    		
    		 var riddle = new Riddle();
                 Console.WriteLine(((Counter)riddle.counter).Increment());
                ///////////////////////////////////////////
                Console.WriteLine(((Counter)riddle.counter).Count);
                // Why the output is 0?///////////////////
    	}
    	
    	
    }
    struct Counter
            {
                private int x;
    	        
    			//Change is here	
                public int Increment() { this.x++; return this.x; }
                public int Count { get { return this.x; } }
            }
    
            class Riddle
            {
                public readonly object counter = new Counter();
            }
