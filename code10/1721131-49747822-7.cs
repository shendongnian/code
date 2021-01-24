    public static void Main()
    {
       // create some ip addresses that might work
       var list = GenerateIPAddressList("192.168.1.1","192.168.1.5");
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
