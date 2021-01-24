	var input = "42,666 towels";
	
	// Get a char[] of all numbers or separators (',' or '.', depending on language):
	var numericChars = input
                        .TakeWhile(c => c == ',' || c == '.' || Char.IsNumber(c))
                        .ToArray();
	
	// Use the chars to init a new string, which can be parsed to a number: 
	var nr = Double.Parse(new String(numericChars));
	
	// ...and the remaining part of the original string is the unit:
	// (Note that we use Trim() to remove any whitespace between the number and the unit)
	var unit = input.Substring(numericChars.Count()).Trim();
	
	// Outputs: Nr is 42,666, unit is towels.
	Console.WriteLine($"Nr is {nr}, unit is {unit}.");
