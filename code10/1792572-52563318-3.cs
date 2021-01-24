    var primes = Tuple.Create(2, 3, 5, 7, 11, 13);
    List<int> primes_li = new List<int>()
    {
    	primes.Item1,
    	primes.Item2,
    	primes.Item3,
    	primes.Item4,
    	primes.Item5,
    	primes.Item6
    };
    var results = primes_li.Where(p => p > 3);
