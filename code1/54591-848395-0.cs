	public static DateTime NextAugust(DateTime input)
	{
		switch(input.Month.CompareTo(8))
		{
			case -1:
			case 0: return new DateTime(input.Year, 8, 31);
			case 1:
				return new DateTime(input.Year + 1, 8, 31);
			default:
				throw new ApplicationException("This should never happen");
		}
	}
