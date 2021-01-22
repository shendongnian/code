	var date = new DateTime(2010, 1, 1, 16, 0, 0);
	foreach (CultureInfo cultureInfo in CultureInfo.GetCultures(CultureTypes.InstalledWin32Cultures))
	{
		bool amMethod = String.IsNullOrEmpty(cultureInfo.DateTimeFormat.AMDesignator);
		bool formatMethod = cultureInfo.DateTimeFormat.ShortTimePattern.Contains("H");
		
		if (amMethod != formatMethod)
		{
			Console.WriteLine("**** {0} AM: {1} Format: {2} Designator: {3}  Time: {4}",
			                  cultureInfo.Name,
			                  amMethod,
			                  formatMethod,
			                  cultureInfo.DateTimeFormat.AMDesignator,
			                  date.ToString("t", cultureInfo.DateTimeFormat));
		}
	}
