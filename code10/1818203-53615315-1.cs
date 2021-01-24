    using System;
					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(Test());
    	}
    	public static string Test() 
    	{
    		var response = "Hi";
    		try
    		{
    			response = "bye";
    			return response;
    		}catch(Exception ex){
    			response = "fail";
    		}finally{
    			response = "finally";
    		}
    		return response;
    	}
    }
