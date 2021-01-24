   	public int AddMinutes(this int source, int minutes)
	{
		return int.Parse(
			DateTime.ParseExact(source.ToString("0000"), "HHmm", null)
					.AddMinutes(minutes)
			.ToString("HHmm"));
	}
