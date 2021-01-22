      DateTime startPeriod = 
         new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-6);
      var query1 = from a in db.Accounts where a.Date_Assigned >= startPeriod
 	 group a by new { a.Date_Assigned.Year  ,a.Date_Assigned.Month  } into result
 	 select new
 	 {
    	 dt = new DateTime( result.Key.Year, result.Key.Month , 1),
         MonthTotal = result.Sum(i => i.Amount_Assigned)
  	 } ;  			 
      var dict = query1.OrderBy(p=> p.dt).ToDictionary(n => n.Dt.ToString("MMM") , n => n.MonthTotal );
