    string str = "012wxyz789";
    Console.Write("The letters in are:");
    foreach (char c in str) { //same result as foreach (char c in str.ToCharArray())
    	if (char.IsLetter(c))
    		Console.Write(c);
    }
