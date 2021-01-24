	public static List<DateTime> A_Week_1 
	{
		get
		{
			var week = (List<DateTime>)HttpContext.Current.Session["A_Week_1"];
			if(week1 == null)
			{
				week1 = new List<DateTime>();
				HttpContext.Current.Session["A_Week_1"] = week1;
			}
			return week1;
		}
	}
