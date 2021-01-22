    class Program
      {
        static void Main(string[] args)
        {
          long numberToTest = 350124;
          bool isPrime = NumberIsPrime(numberToTest);
          Console.WriteLine(string.Format("Number {0} is prime? {1}", numberToTest, isPrime));
          Console.ReadLine();
        }
    
        private static bool NumberIsPrime(long n)
        {
          bool retVal = true;
    
          if (n <= 3)
          {
            retVal = n > 1;
          } else if (n % 2 == 0 || n % 3 == 0)
          {
            retVal = false;
          }
    
          int i = 5;
    
          while (i * i <= n)
          {
            if (n % i == 0 || n % (i + 2) == 0)
            {
              retVal = false;
            }
            i += 6;
          }
    
          return retVal;
        }
      }
