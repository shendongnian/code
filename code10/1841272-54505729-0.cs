    BigInteger prevPrev = BigInteger.Parse(Console.ReadLine());
    BigInteger prev = BigInteger.Parse(Console.ReadLine());
    BigInteger current = BigInteger.Parse(Console.ReadLine());
	
	BigInteger N = BigInteger.Parse(Console.ReadLine());
    
	for(int i = 3; i < N; i++)
	{
		// calculate next number
		var next = prevPrev + prev + current;
		
		// shift all numbers
		prevPrev = prev;
		prev = current;
		current = next;
	}
	
	return current;
