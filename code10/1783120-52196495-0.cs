		var line1 = "Duration : 00:05:48.73";
		var line2 = "File Size 61.5M";
		
		Regex _regex = new Regex(@"^([\p{L}_ ]+):?(.+)$");
		Match match = _regex.Match(line1);
		if (match.Success)
		{
			string key = match.Groups[1].Captures[0].Value;
			string value = match.Groups[2].Captures[0].Value;
			
			//call trim to remove extra space around.
			Console.WriteLine(key.Trim());  //Duration
			Console.WriteLine(value.Trim());  //00:05:48.73
		}
		
		match = _regex.Match(line2);
		if (match.Success)
		{
			string key = match.Groups[1].Captures[0].Value;
			string value = match.Groups[2].Captures[0].Value;
			
			//call trim to remove extra space around.
			Console.WriteLine(key.Trim());   //File Size
			Console.WriteLine(value.Trim()); //61.5M
		}
