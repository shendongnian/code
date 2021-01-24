    using System;
    
    public class Program
    {
    	
    	public static DateTime NextDayForDay(DayOfWeek dayOfWeek, DateTime occurringAfter)
    	{
    		return occurringAfter.AddDays(((dayOfWeek - occurringAfter.DayOfWeek + 6) % 7)+1); 
    	}
    	
    	public static void Main()
    	{
    		for (int i=0; i < 7; i++)
    		{
    			for (int j=0; j < 7; j++)
    			{
    				DayOfWeek dayOfWeek = (DayOfWeek)(((int)DayOfWeek.Sunday + j) % 7);
    				
    				DateTime test = DateTime.Today.AddDays(i);
    				Console.WriteLine($"{test}=>Next {dayOfWeek} is {NextDayForDay(dayOfWeek, test)}");
    			}
    		}	
    	}
    }
