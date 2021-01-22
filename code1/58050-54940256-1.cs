	DateTime end = new DateTime();
	end = DateTime.ParseExact("22:00:00", "H:m:s", null);
	if (DateTime.Now > end.AddMinutes(15))
	{
        //if time is greater than 22:15:00 do whatever you want
    }
