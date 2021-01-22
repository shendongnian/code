	DateTime begin = new DateTime();
	begin = DateTime.ParseExact("21:00:00", "H:m:s", null);
	if (DateTime.Now < begin.AddMinutes(-15))
	{
	    //if time is before 19:45:00 show message etc...
	}
