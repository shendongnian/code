	static string ToHMString(TimeSpan timespan) { 
		if (timespan.Ticks < 0) return "-" + ToHMString(timespan.Negate());
		
		return timespan.TotalHours.ToString("#0") + ":" + timespan.Minutes.ToString("00");
	}
	Console.WriteLine(ToHMString(TimeSpan.FromHours(3)));		//Prints "3:00"
	Console.WriteLine(ToHMString(TimeSpan.FromHours(-27.75)));	//Prints "-28:45"
