		// split on both space and closing bracket
        // Assumption: GPA field is present and at the end
		Console.WriteLine(line.Split(new[] { " ", ")" }, StringSplitOptions.RemoveEmptyEntries).LastOrDefault());
		
		// regex for gpa defined as digit followed by literal . followed by one or more digits
        // Assumption: GPA field is present once somewhere in the string.
        // No other token conflicts with similar format
		var gpaRegex = new Regex(@"\d\.\d+");
		Console.WriteLine(gpaRegex.Matches(line)[0]);
