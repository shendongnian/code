    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		int[] input = new int[] {10, 0 , 0, 0} ;
    		
    		
    		string b1 = Convert.ToString(input[0], 2).PadLeft(32, '0');
    		string b2 = Convert.ToString(input[1], 2).PadLeft(32, '0');
    		string b3 = Convert.ToString(input[2], 2).PadLeft(32, '0');
    		
    		decimal result = 0;
    		
    		string s = b3+b2+b1;
    		
    		Console.WriteLine("Binary : "+s);
    		
    		for( int i=0; i<s.Length; i++ ) 
    		{
    		  // we start with the least significant digit, and work our way to the left
    		  if( s[s.Length-i-1] == '0' ) continue;
    		  result += (decimal)Math.Pow( 2, i );
    		   Console.WriteLine(result);
    		}
    				
    						
    		Console.WriteLine("Calculated " + result );
    		Console.WriteLine("By Framework " + (new decimal(input)));
    		
    	
    	}
    }
 
