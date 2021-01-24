	public IEnumerable<int> GetHours()
	{
		List<int> hours = new List<int>();
		var startDate = StartDate;
		var finishDate = FinishDate;
		while(startDate < finishDate)
		{
			hours.Add(startDate.Hour);
			startDate = startDate.AddHours(1);
		}
		return hours;
	}
