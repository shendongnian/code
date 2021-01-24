    class Program
    {
          static void Main(string[] args)
          {
               string input = Console.ReadLine();
               int d;
               if (int.TryParse(input, out d))
               Console.WriteLine(string.Concat(Enumerable.Repeat("Whatever",d)));
               Console.ReadLine();
          }
    }
