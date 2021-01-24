    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		bool read = true;
    		List<int> list = new List<int>();
    		do{
    			string input = Console.ReadLine();
    			int x = 0; 
    			if(input == "start")
                {
    				read = false;
    			}
    		    else if(int.TryParse(input, out x))
                {
    				list.Add(x);
    			}
    			else 
                {
    				Console.WriteLine("Invalid Input");
    			}
    		} while(read);
    		foreach(var z in list)
            {
    		    Console.WriteLine(z);	
    		}
    	}
    }
