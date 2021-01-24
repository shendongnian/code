    using System;
    using System.Collections.Generic;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		var selectedDayOfWeeks = new List<DayOfWeek>{DayOfWeek.Thursday, DayOfWeek.Saturday};
    		var startDate = new DateTime(2017, 10, 24);
    		var endDate = new DateTime(2017, 10, 28);
    		
    		var possibleDates = new List<DateTime>();
    		for(var current = startDate; current <= endDate; current= current.AddDays(1))
    		{
    			if(selectedDayOfWeeks.Contains(current.DayOfWeek))
    			{
    				possibleDates.Add(current);
    			}
    		}
    		
    		foreach(var d in possibleDates){
    			Console.WriteLine(d);
    		}
    		
    	}
    }
