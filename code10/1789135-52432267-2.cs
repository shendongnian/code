	var nrFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
	
    // Remove or add strings to this list as needed:
    var validStrings = 
		new List<string>{ 
						nrFormat.NaNSymbol, 
						nrFormat.NegativeSign, 
						nrFormat.NumberDecimalSeparator, 
						nrFormat.PercentGroupSeparator, 
						nrFormat.PercentSymbol, 
						nrFormat.PerMilleSymbol, 
						nrFormat.PositiveInfinitySymbol, 
						nrFormat.PositiveSign
					};
					
	validStrings.AddRange(nrFormat.NativeDigits);
	validStrings.Add("^");
	validStrings.Add("e");
	
	
	// You can use more complex numbers, like: 
	var input = "-42,666e-3 Towels";
    
	// Get all numbers or separators (',' or '.', depending on language):
	var numericChars = input.TakeWhile(c => validStrings.Contains("" + c)).ToArray();
	
	// Use the chars to init a new string, which can be parsed to a number: 
	var nr = Double.Parse(new String(numericChars));
	
	// ...and the remaining part of the original string is the unit:
	// (Note that we use Trim() to remove any whitespace between the number and the unit)
	var unit = input.Substring(numericChars.Count()).Trim();
	
	// Outputs is now: "Nr is -0,042666, unit is Towels"
	Console.WriteLine($"Nr is {nr}, unit is {unit}.");
	
