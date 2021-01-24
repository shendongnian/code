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
      for (var i = 0; i < 300; i++)
      {
         Console.WriteLine($"result {i + 1}: \t" + CompareProps(alist[i], blist[i]));
      }
      Console.WriteLine(watch.Elapsed.TotalSeconds + "  seconds..");
    }
