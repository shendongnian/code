		public static bool LiesAfterIgnoringMilliseconds(this DateTime theDate, DateTime compareDate, DateTimeKind kind)
		{
			DateTime thisDate = new DateTime(theDate.Year, theDate.Month, theDate.Day, theDate.Hour, theDate.Minute, theDate.Second, kind);
			compareDate = new DateTime(compareDate.Year, compareDate.Month, compareDate.Day, compareDate.Hour, compareDate.Minute, compareDate.Second, kind);
			return thisDate > compareDate;
		}
		public static bool LiesAfterOrEqualsIgnoringMilliseconds(this DateTime theDate, DateTime compareDate, DateTimeKind kind)
		{
			DateTime thisDate = new DateTime(theDate.Year, theDate.Month, theDate.Day, theDate.Hour, theDate.Minute, theDate.Second, kind);
			compareDate = new DateTime(compareDate.Year, compareDate.Month, compareDate.Day, compareDate.Hour, compareDate.Minute, compareDate.Second, kind);
			return thisDate >= compareDate;
		}
