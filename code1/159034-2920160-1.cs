		string a = "\u00C4";       // "LATIN CAPITAL LETTER A WITH DIAERESIS"
		string b = "\u0041\u0308"; // "LATIN CAPITAL LETTER A" - "COMBINING DIAERESIS"
		Console.WriteLine(a.Equals(b, StringComparison.InvariantCulture)); // true
		Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US", false);
		Console.WriteLine(a.Equals(b, StringComparison.CurrentCulture));   // true
		Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK", false);
		Console.WriteLine(a.Equals(b, StringComparison.CurrentCulture));   // false
		Console.WriteLine(a.Equals(b, StringComparison.Ordinal));          // false
