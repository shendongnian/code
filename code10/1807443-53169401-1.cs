	public static bool IsBetween(TimeSpan time, TimeSpan start, TimeSpan end)
        => (start <= end) ? time >= start && time <= end : time >= start || time <= end;
		
	internal void TestMethod()
	{
	    var timeSlots = new[] {
			new TimeFrame { start= new TimeSpan(6,0,0) , end = new TimeSpan(13,0,0) },
			new TimeFrame { start= new TimeSpan(14,0,0) , end = new TimeSpan(21,0,0) },
			new TimeFrame { start= new TimeSpan(22,0,0) , end = new TimeSpan(6,0,0) }
		};
		var today = DateTime.Today;
		var dayHours = Enumerable.Range(0, 24).Select(x => today.AddHours(x)).ToList();
		foreach (var currentDateTime in dayHours)
		{
			var matchingRanges = timeSlots.Where(x => IsBetween(currentDateTime .TimeOfDay, x.start, x.end));
			if (matchingRanges.Any())
			{
				var temp = matchingRanges.First();
				Console.WriteLine($"-> {currentDateTime } is in range {temp.start}-{temp.end}");				
				Console.WriteLine($"\t ShiftHours= {temp.start}-{temp.end.Subtract(new TimeSpan(0, 0, 1))}");
			}
			else
			{
				Console.WriteLine($"no Match for {currentDateTime }");
			}
		}
	}
