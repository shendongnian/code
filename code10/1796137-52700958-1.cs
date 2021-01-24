    var finalNumber = int.Parse(Console.ReadLine());
    for (int i = 0; i < finalNumber; i++)
    {
    	bool prime = PrimeHelper.IsPrime(i);
    	if (prime)
    	{
    	Console.Write("Prime: ");
    	Console.WriteLine(i);
    	}
    }
