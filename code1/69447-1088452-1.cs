    static IEnumerable<int> GetPrimeNumbers() {
       for (int num = 2; ; ++num) 
           if (IsPrime(num))
               yield return num;
    }
    static void Main() { 
       foreach (var i in GetPrimeNumbers()) 
           if (i < 10000)
               Console.WriteLine(i);
           else
               break;
    }
