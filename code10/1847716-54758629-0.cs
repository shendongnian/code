	var input = "12345";
	var working = input.PadLeft(input.Length + input.Length % 2, '0');
	var result =
		Enumerable
			.Range(0, working.Length / 2)
			.Select(x => $"{working.Substring(x * 2, 2)}")
			.Select(x => byte.Parse(x, System.Globalization.NumberStyles.HexNumber));
