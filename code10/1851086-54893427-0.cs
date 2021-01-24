    class Program
    {
      static void Main(string[] args)
      {
        Console.WriteLine("Enter Your Hashsum.");
        string myhash = Console.ReadLine();
        var words = myhash.ToCharArray().Select(c => $"{c}");
        Console.WriteLine("Modified Hashsum:");
        foreach (var word in words)
        {
          System.Console.Write($"\"{word}\", ");
        }
        Console.ReadKey();
      }
    }
