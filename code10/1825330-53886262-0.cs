    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static List<DateTime> getDates()
    	{
    		DateTime d1 = new DateTime(2018,1,1);
    		DateTime d2 = new DateTime(2018,5,1);
    		DateTime d3 = new DateTime(2018,12,1);
    		
    		List<DateTime> db = new List<DateTime>();
    		
    		db.Add(d1);
    		db.Add(d2);
    		db.Add(d3);
    		
    		return db;		
    	}
    	
    	public static void Main()
    	{
    		var model = getDates();		
    		DateTime tenMonthsAgo = DateTime.Today.AddMonths(-10);		
    		
    		var query = model.Where(dates => dates.Month > tenMonthsAgo.Month);
    		
    		foreach (var q in query)
    		{
    			Console.WriteLine("res: " + q);	
                 //res:5/1/2018 12:00:00 AM
                 //res:12/1/2018 12:00:00 AM
    		}
    	}
    }
