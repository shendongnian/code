	public static partial class MyExtensions
	{
		public static DateTime AddBusinessDays(this DateTime date, int addDays)
		{
			while (addDays != 0)
			{
				date = date.AddDays(Math.Sign(addDays));
				if (MyClass.IsBusinessDay(date))
				{
					addDays = addDays - Math.Sign(addDays);
				}
			}
			return date;
		}
	}
