     using System;
     				
     public class Program
     {
     	public static void Main()
     	{
     		TimeSpan t=new TimeSpan(20,00,00);//Time to check
     		
     		TimeSpan start = new TimeSpan(20, 0, 0); //8 o'clock evening
     		
     		TimeSpan end = new TimeSpan(08, 0, 0); //8 o'clock Morning
     		
     		if ((start>=end && (t<end ||t>=start))||(start<end && (t>=start && t<end)))
     		{
     		   Console.WriteLine("Mached");
     		}
     		else
     		{
     			Console.WriteLine("Not Mached");
     		}
     		
     	}
     }
