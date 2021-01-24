    // this includes the Trim() suggested by the others
	string cheatExpiration = System.IO.File.ReadAllText(@"C:\xWQcixf07xES5yf5V5A6\UKI9nRuJgZA611zQCyIq.txt").Trim();
	DateTime cExpiration = DateTime.ParseExact(cheatExpiration, "yyyy/MM/dd HH:mm", System.Globalization.CultureInfo.InvariantCulture);
	if (DateTime.Today < cExpiration)
	{
	}
