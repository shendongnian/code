    TimeSpan totalSum = TimeSpan.Zero;
	List<TimeSpan> orderedTimespans = dt.AsEnumerable()
		.Select(r => TimeSpan.Parse(r.Field<string>("StartEnd")))
		.OrderBy(ts => ts)
		.ToList();
	for (int index = 0; index < orderedTimespans.Count; index+=2)
	{
		TimeSpan tsStart = orderedTimespans[index];
		TimeSpan tsEnd = orderedTimespans[index + 1];
		totalSum += tsEnd - tsStart;
	}
