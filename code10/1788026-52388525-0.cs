    internal static class Program
    {
      private const string wrongLine = "v-dakash@catalysis.com,\"HEY\"? Tester, 12345789,\"Catalysis\", LLC., Enterprise 6 TEST, etc,etc ,etc";
      private static readonly Regex wrongPattern = new Regex("\"[^\"]*\"|'[^']*'|[^,;]+");
      private static readonly Regex fixedPattern = new Regex("((?:\"(?:[^\"]|\"\")*\")|(?:'([^']|'')*')|(?:[^,;]*))(?:[,;]|$)");
      private static void Main()
      {
        var matches = wrongPattern.Matches(wrongLine);
        for (int i = 0; i < matches.Count; i++)
        {
          Console.WriteLine("'" + matches[i].Value + "'");
        }
        Console.WriteLine();
        Console.WriteLine("-------------");
        Console.WriteLine();
        matches = fixedPattern.Matches(wrongLine);
        for (int i = 0; i < matches.Count; i++)
        {
          Console.WriteLine("'" + matches[i].Groups[1].Value + "'");
        }
      }
    }
