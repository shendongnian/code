    using System;
    using System.Text;
    
    class Program {
      static void Main(string[] args) {
        StringBuilder sb = new StringBuilder();
        try {
          //sb.Capacity = 690 * 1024 * 1024;
          while (true) sb.Append("asdf");
        }
        catch (OutOfMemoryException) {
          Console.WriteLine("Died at: {0:N0} characters", sb.Capacity);
          Console.WriteLine("Memory used: {0:N0} bytes", GC.GetTotalMemory(false));
          Console.ReadLine();
        }
      }
    }
