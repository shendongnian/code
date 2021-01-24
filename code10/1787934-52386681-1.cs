    Coordinate coord = null;
    string errorMessage = string.Empty;
	var success = Coordinate.TryParse("3.14, 15.28b", out coord, out errorMessage);
	if (!success) {
	    Console.WriteLine("Error: " + errorMessage);
		Console.WriteLine("Coordinate is valid?: " + coord.IsValid());
	}
	else {
		Console.WriteLine("Success: " + coord.ToString());
	}
    
