	static (int, char, int) vowelStatsPlain(string str)
	{
		// VOWEL ONLY DICTIONARY
		Dictionary<char, int> counts = new Dictionary<char, int>()
		{
			{'a', 0} , { 'e', 0} , { 'i', 0} , { 'o', 0} , { 'u', 0}
		};
	
		int vowels = 0;
		char high = '\0';
	
		foreach (char c in str)
		{
			char c1 = Char.ToLower(c); // convert letter to lowercase first
									   // if dictionary has the character, then it must be a vowel
			if (counts.ContainsKey(c1))
			{
				counts[c1]++;  // vowel itself count
				vowels++;      // total vowel count
				if (!counts.ContainsKey(high)) high = c1; // will only be true once
				if (vowels - counts[c1] < vowels - counts[high]) // update current most frequent
					high = c1;
			}
		}
	
		if (!counts.ContainsKey(high)) // if no vowels found, high will be '\0'
			return (0, '\0', 0);
		return (vowels, high, counts[high]);
	}
	
	static (int, char, int) vowelStatsLinq(string str)
	{
		var query =
		(
			from v in "aeiouAEIOU"
			join c in str on v equals c
			group c by c into gcs
			orderby gcs.Count() descending
			select gcs
		).ToArray();
	
		var first = query.First();
	
		return (query.SelectMany(c => c).Count(), first.Key, first.Count());
	}
	
	static void Main(string[] args)
	{
		string input = "The information contained in this email is confidential and for the addressee only; If you are not the intended recipient of this email, please reply and let us know that an incorrect address may have been used. If you do not wish to be communicated with by email, please respond so that we may remove your address from our records. Your co-operation is appreciated.";
	
		Func<TimeSpan> callPlain = () =>
		{
			var sw = Stopwatch.StartNew();
			(int vowels, char mostFrequenctVowel, int mostFrequentVowelCount) = vowelStatsPlain(input);
			sw.Stop();
			return sw.Elapsed;
		};
	
		Func<TimeSpan> callLinq = () =>
		{
			var sw = Stopwatch.StartNew();
			(int vowels, char mostFrequenctVowel, int mostFrequentVowelCount) = vowelStatsLinq(input);
			sw.Stop();
			return sw.Elapsed;
		};
	
		var trials = Enumerable.Range(0, 1000000).Select(x => new { plain = callPlain(), linq = callLinq() }).ToArray();
	
		Console.WriteLine(trials.Skip(2).Average(x => x.plain.TotalMilliseconds));
		Console.WriteLine(trials.Skip(2).Average(x => x.linq.TotalMilliseconds));
		Console.WriteLine(trials.Skip(2).Average(x => x.linq.TotalMilliseconds) / trials.Skip(2).Average(x => x.plain.TotalMilliseconds));
	}
