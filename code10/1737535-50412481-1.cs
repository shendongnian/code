    var text = "abc";
		
	var predicates = new Func<char, bool>[] { 
		x => char.IsLetter(x) || x == 'X', 
		char.IsDigit 
	};
		
	var result = predicates.Any(text.All);
	
    // Outputs TRUE	
	Console.WriteLine(result);
