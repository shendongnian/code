    using System;
    using System.Dynamic;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
            var args = "--Bar --Foo MyStuff".Split();
            var parsedArgs = ParseArgs(args);
            Console.WriteLine(parsedArgs.Foo); //Writes "MyStuff"
    		Console.WriteLine(parsedArgs.Bar); //Writes true;
    		Console.WriteLine(parsedArgs.NotDefined); //Throws run time exception.
    	}
    	
    	public static dynamic ParseArgs(string[] args)
        {
            IDictionary<string,object> result = new ExpandoObject();
            //Very basic implementation
    		for(int i = 0; i < args.Length; i++)
    		{
    			if(args[i].StartsWith("--"))
    			{
    				if(i+1 < args.Length && !args[i+1].StartsWith("--"))
    				{
    					result.Add(args[i].Substring(2), args[i+1]);
    				}
    				else
    				{
    					result.Add(args[i].Substring(2), true);
    				}
    			}
    		}
    		return result;
        }
    }
