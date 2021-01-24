    public static IEnumerable<int> GetFibonacciSequence()
    {
       yield return 0;
       yield return 1;
       yield return 2;
       int previousMinusOne = 0;
       int previous = 1;
       int current = 2;
       while (true)
       {
          int next = previous + previousMinusOne + current;
          previousMinusOne = previous;
          previous = current;
          current = next;
          yield return next;
       }
    }
    
    foreach (var val in GetFibonacciSequence().Take(15))
    {
      Console.WriteLine(val);
    }
