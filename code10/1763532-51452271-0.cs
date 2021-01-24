    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		string d = "The @quick @brown fox @jumps over @the lazy @dog";
    		string textChars = "@#^*+";
    
            char[] specialChars = textChars.ToCharArray();
    
    		Console.WriteLine("Before: {0}: ", d);
    		bool specialCharFound = true;
    		while (specialCharFound)
    		{
    			specialCharFound = false;
    			for (int i = 0; i < specialChars.Length; i++)
    			{	
    				if (d.Contains(specialChars[i].ToString()))
    				{
    					specialCharFound = true;
    					d = d.Remove(d.IndexOf(specialChars[i]), 1);					
    				}
    			}
    		}
    		
    		Console.WriteLine("After : {0}: ", d);
    	}
    }
