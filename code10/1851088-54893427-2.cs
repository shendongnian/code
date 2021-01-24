    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Enter Your Hashsum.");
        var words = Console.ReadLine().ToCharArray().Select(c => $"{c}");
        Console.WriteLine("Modified Hashsum:");
        Console.Write("\"" + words.Aggregate((c, n) => $"{c}\",\"{n}") + "\"");
        Console.ReadKey();
      }
    }
