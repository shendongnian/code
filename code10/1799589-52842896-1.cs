	var utcDateDuringDaylightSavingsTime = new DateTime(2018, 7, 1, 15, 30, 30, DateTimeKind.Utc);
	TimeZoneInfo pacificZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
	var localDateDuringDaylightSavingsTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateDuringDaylightSavingsTime, pacificZone);
	var localDateNotDuringDaylightSavingsTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateDuringDaylightSavingsTime.AddMonths(5), pacificZone);
	Console.WriteLine(utcDateDuringDaylightSavingsTime.ToString("o") + "\t\tUTC");
	Console.WriteLine(localDateDuringDaylightSavingsTime.ToString("o") + "\t\t Local during daylight saving");
	Console.WriteLine(localDateNotDuringDaylightSavingsTime.ToString("o") + "\t\t Local not during daylight saving");
