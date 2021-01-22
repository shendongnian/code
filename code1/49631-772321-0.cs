    using System;
    using System.IO;
    
    public static void Main(String[] args)
    {
      ConsoleKeyInfo k;
      Console.WriteLine("Enter q to exit:");
      do {
        k = Console.ReadKey();
        Console.WriteLine(k.KeyChar);
      } while (k.KeyChar != 'q');
      return 0;
    }
