    List<int> primes=new List<int>(new int[]{2,3});
    for (int n = 5; primes.Count< numberToGenerate; n+=2)
    {
      bool isPrime = true;
      foreach (int prime in primes)
      {
        if (n % prime == 0)
        {
          isPrime = false;
          break;
        }
      }
      if (isPrime)
        primes.Add(n);
    }
