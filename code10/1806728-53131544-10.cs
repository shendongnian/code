    private static void Run()
    {
      var alist = new List<MyObject>();
      for (var i = 0; i < 300; i++)
      {
        alist.Add(new MyObject
        {
            prop1 = "abc",
            prop2 = RandomString(),
            prop3 = random.Next(),
            prop4 = 123
        });
      }
    
      var blist = new List<MyObject>();
      for (var i = 0; i < 300; i++)
      {
         blist.Add(new MyObject
         {
            prop1 = "abc",
            prop2 = RandomString(),
            prop3 = random.Next(),
            prop4 = 123
         });
      }
      
      var watch = new Stopwatch();
      watch.Start();
      
      Parallel.For(0, alist.Count, i =>
      {
         for (var j = 0; j < blist.Count; j++)
         {
            Console.WriteLine("Result: " + CompareProps(alist[i], blist[j]));
         }
      });
      
      Console.WriteLine(watch.Elapsed.TotalSeconds + "  seconds..");
    }
