    public static IEnumerable<int> GetSequence()
    {
       //hardcode returning the first 3 items
       yield return 0;
       yield return 1;
       yield return 2;
       //define the initial values for the iteration
       int previousMinusOne = 0;
       int previous = 1;
       int current = 2;
       //loop forever (in reality, we might overflow)
       while (true)
       {
          int next = previous + previousMinusOne + current;
          //shift the 3 values, losing the previousMinusOne one (we no longer need it)
          previousMinusOne = previous;
          previous = current;
          current = next;
          //return our result and yield the thread
          yield return next;
       }
    }
    
    //take the first 15 values of the IEnumerable
    foreach (var val in GetSequence().Take(15))
    {
      Console.WriteLine(val);
    }
