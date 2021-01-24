	string[] numbers = { "1234", "0876", "9876", "45614537", "7553" };
	var result = numbers.Aggregate(new List<string>(), (p,c) => {
		if (c.Length > 4) {
			p.Add(c.Substring(0,4));  // get the first 4 characters
			p.Add(c.Substring(4));    // get the remaining characters
		}
		else {
			p.Add(c);
		}
		return p;
	});
