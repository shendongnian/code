    public void PrintAllPrimes()
    {
        var numbers = new PrimeNumbers();
    
        // This will never end but it'll print all primes until my PC crash
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
