    using System;
    
    public class Program
    {
    	public static void Main()
    	{
    		string ReturnedFromSQL = "FAB01";
    		string Input = "Fab01";
    		if (String.Equals(ReturnedFromSQL, Input, StringComparison.CurrentCultureIgnoreCase))
    		{
    			Console.WriteLine("Equal");
    		}
    		else
    		{
    			Console.WriteLine("Different");
    		}
    	}
    }
