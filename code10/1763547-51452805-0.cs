    using System;
    using System.Text;
    
    public class Program
    {
    	public static void Main()
    	{
    		StringBuilder sb = new StringBuilder();
    		for (int i = 0; i <= 999999; i++)
    		{
    			sb.AppendLine(i.ToString("000000"));
    		}
    		
    		Console.WriteLine(sb);
    	}
    }
