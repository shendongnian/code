    TimeSpan totalSum = TimeSpan.Zero;
	foreach (DataRow dr in dt.Rows)
	{
		string[] HourAndMinute = dr["StartEnd"].ToString().Split(); //This String contains 08:50 10:30 ...
		TimeSpan tsStart = TimeSpan.Parse(HourAndMinute[0].Trim());
		TimeSpan tsEnd = TimeSpan.Parse(HourAndMinute[1].Trim());
		totalSum += tsEnd - tsStart;
	}
