    static void Main(string[] args)
    {
      foreach (var nc in NetworkInterface.GetAllNetworkInterfaces())
      {
        Console.WriteLine(nc.Name);
      }
    
      Console.ReadLine();
    }
