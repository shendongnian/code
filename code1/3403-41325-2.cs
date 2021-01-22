     IEnumerable<Object> myList = new List<Object>();
     Stopwatch watch = new Stopwatch();
     int x;
     watch.Start();
     for (var i = 0; i <= 1000000; i++)
     {
        if (myList.Count() == 0) x = i; 
     }
     watch.Stop();
     Stopwatch watch2 = new Stopwatch();
     watch2.Start();
     for (var i = 0; i <= 1000000; i++)
     {
         if (!myList.Any()) x = i;
     }
     watch2.Stop();
     Console.WriteLine("myList.Count() = " + watch.ElapsedMilliseconds.ToString());
     Console.WriteLine("myList.Any() = " + watch2.ElapsedMilliseconds.ToString());
     Console.ReadLine();
