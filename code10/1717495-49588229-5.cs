   	public static int AddMinutes(this int source, int minutes)
	{
		return int.Parse(
			DateTime.ParseExact(source.ToString("0000"), "HHmm", null)
					.AddMinutes(-45)
			.ToString("HHmm"));
	}
