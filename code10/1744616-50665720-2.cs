    Stopwatch stopWatch = new Stopwatch();
    stopWatch.Start();
    for (int i = n; i <= m; i++)
    {
       if (checkIfPalindromic(i.ToString()))
       {
          if (checkIfPalindromic((i * i).ToString()))
             Console.WriteLine(i);
       }
    }
    stopWatch.Stop();
    Console.WriteLine("First approach: Elapsed time..." + stopWatch.Elapsed + " which is " + stopWatch.Elapsed.TotalMilliseconds + " miliseconds");
