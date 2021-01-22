    public void main(string args[])
    {
        //Get the number you want to use as input
        long x = number;//'number' can be hard coded or retrieved from ReadLine() or from the given arguments
    
        IList<long> primes = FindSmallerPrimes(number);
    
        DisplayPrimes(primes);
    }
    
    public IList<long> FindSmallerPrimes(long largestNumber)
    {
        List<long> returnList = new List<long>();
        //Find the primes, using a method as described by another answer, add them to returnList
        return returnList;
    }
    
    public void DisplayPrimes(IList<long> primes)
    {
        foreach(long l in primes)
        {
            Console.WriteLine ( "Prime:" + l.ToString() );
        }
    }
