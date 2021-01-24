	string input = "This is a test string which could be any text";
	string exclude = "aeiou";
	var stripped = Regex.Replace(input, $[{exclude}], ""); // exclude chars
	var cleaned = Regex.Replace(stripped, "[ ]{2,}", " "); // replace multiple spaces
    Console.WriteLine(stripped);
	Console.WriteLine(cleaned);
