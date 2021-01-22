        public IEnumerable<long> GetPrimes(int numberPrimes)
        {
          List<long> primes = new List<long> { 1, 2, 3 };
          long startTest = 3;
    
          while (primes.Count() < numberPrimes)
          {
            startTest += 2;
            bool prime = true;
            for (int pos = 2; pos < primes.Count() && primes[pos] <= Math.Sqrt(startTest); pos++)
            {
              if (startTest % primes[pos] == 0)
              {
                prime = false;
              }
            }
            if (prime)
              primes.Add(startTest);
          }
          return primes;
        }
