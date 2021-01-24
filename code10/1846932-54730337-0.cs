	char[] listOfVowels = "aeiouAEIOU".ToCharArray();
	string input = "cheesecake";
	var query =
		from v in listOfVowels
		join c in input on v equals c
		group c by c into gcs
		orderby gcs.Count() descending
		select gcs;
	
	Console.WriteLine($"Vowels: {String.Join(", ", query.SelectMany(c => c))}");
	Console.WriteLine($"Most Frequent Vowel: {query.First().Key}");
	Console.WriteLine($"Most Frequent Vowel Count: {query.First().Count()}");
