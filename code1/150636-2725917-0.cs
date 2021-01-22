    using System;
    
    class Program {
      static void Main(string[] args) {
        var url = new Uri(@"\\houtestmachine\common\F#ile1.pdf");
        Console.WriteLine(url.AbsoluteUri);
        var back = url.LocalPath;
        Console.WriteLine(back);
        Console.ReadLine();
      }
    }
