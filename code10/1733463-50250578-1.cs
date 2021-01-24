    class Program
    {
         static void Main(string[] args)
         {
              int x = 15;
              Console.WriteLine(string.Concat(Enumerable.Repeat("Whatever", x)));
              Console.ReadLine();
          }
    }
