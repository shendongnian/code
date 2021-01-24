    Stopwatch stopWatch2 = new Stopwatch();
    stopWatch2.Start();
    for (int i = n; i <= m; i++)
    {
       if (IsPalindromicNumber(i) && IsPalindromicNumber(i*i))
       {
          Console.WriteLine(i);
       }
    }
    
    stopWatch2.Stop();
    Console.WriteLine("Second approach: Elapsed time..." + stopWatch2.Elapsed + " which is " + stopWatch2.Elapsed.TotalMilliseconds + " miliseconds");
