    public static void Main()
    {
       var data = new byte[4];
       var rand = new Random();
       
       // create some ip addresses that might work
       var list = new List<IPAddress>(){ IPAddress.Loopback, IPAddress.Parse("8.8.8.8"), IPAddress.Parse("1.1.1.1") };
       // add some random ones
       for (var i = 0; i < 10; i++)
       {
          rand.NextBytes(data);
          list.Add(new IPAddress(data));
       }
    
       // start the work load
       DoWorkLoads(list).Wait();
    
       // out put the results
       Console.WriteLine("passed");
       Console.WriteLine("--------");
    
       foreach (var result in _passed)
       {
          Console.WriteLine(result.Item1 + " : " + result.Item2);
       }
    
       Console.WriteLine();
       Console.WriteLine("failed");
       Console.WriteLine("--------");
       foreach (var result in _failed)
       {
          Console.WriteLine(result.Item1 + " : " + result.Item2 + " : error code = " + result.Item3);
       }
    }
