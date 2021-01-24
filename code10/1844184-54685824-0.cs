	List<string> Instruments = new List<string>();
	Instruments.Add("cello");
	Instruments.Add("guitar");
	Instruments.Add("violin");
	Instruments.Add("double bass");
	string vowels = "aeiouy";
	
	var results = vowels.Aggregate(Instruments,
		(i, v) => i.Select(x => x.Replace(v.ToString(), "")).ToList());
