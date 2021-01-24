    using System;
    					
    public class Program
    {	
    	public static void Main()
    	{
    		string[] s = { "saravanan","KArthick","Jackson","saravanan" };
    		for (int i = 0; i < s.Length; i++) 
    		{
    			// Skip empty element
    			if (string.IsNullOrEmpty(s[i]))
    			{
    				continue;
    			}
    			
    			int count = 1;
    			for (int j = i + 1; j < s.Length; j++) 
    			{
    				// Skip empty element
    				if (string.IsNullOrEmpty(s[i]))
    				{
    					continue;
    				}
    				
    				if (s[i] == s[j])
    				{
    					count++;
    					
    					// Clear the element to indicate the element as already been counted
    					s[j] = string.Empty; 
    				}
    			}
    			
    			Console.WriteLine("{0} occurs {1} times", s[i], count);
    		}
    	}
    }
