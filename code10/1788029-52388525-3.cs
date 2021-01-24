    internal static class Program
    {
      private const string wrongLine = "v-dakash@catalysis.com,\"HEY\"? Tester, 12345789,\"Catalysis\", LLC., Enterprise 6 TEST, etc,etc ,etc";
      private const string fixedLine = "v-dakash@catalysis.com,\"\"\"HEY\"\"? Tester\", 12345789,\"Catalysis\", LLC., Enterprise 6 TEST, etc,etc ,etc";
      private static readonly Regex wrongPattern = new Regex("\"[^\"]*\"|'[^']*'|[^,;]+");
      private static readonly Regex fixedPattern = new Regex("((?:\"((?:[^\"]|\"\")*)\")|(?:'((?:[^']|'')*)')|([^,;]*))(?:[,;]|$)");
      private static void Main()
      {
        Console.WriteLine("***  Wrong line: ***");
        Console.WriteLine();
        Parse(wrongLine);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("***  Fixed line: ***");
        Console.WriteLine();
        Parse(fixedLine);
      }
      private static void Parse(string line)
      {
        Console.WriteLine("--- [Original Regex] ---");
        var matches = wrongPattern.Matches(line);
        for (int i = 0; i < matches.Count; i++)
        {
          Console.WriteLine("'" + matches[i].Value + "'");
        }
        Console.WriteLine();
        Console.WriteLine("--- [Fixed Regex] ---");
        Console.WriteLine();
        matches = fixedPattern.Matches(line);
        for (int i = 0; i < matches.Count; i++)
        {
          Console.WriteLine("'" + GetValue(matches[i]) + "'");
        }
        Console.WriteLine();
        Console.WriteLine("--- [Correct(?) parser] ---");
        Console.WriteLine();
        var position = 0;
        while (position < line.Length)
        {
          var value = GetValue(line, ref position);
          Console.WriteLine("'" + value + "'");
        }
      }
      private static string GetValue(Match match)
      {
        if (!string.IsNullOrEmpty(match.Groups[2].Value))
        {
          return (match.Groups[2].Value.Replace("\"\"", "\""));
        }
        if (!string.IsNullOrEmpty(match.Groups[3].Value))
        {
          return (match.Groups[3].Value.Replace("''", "'"));
        }
        return (match.Groups[4].Value.Replace("''", "'"));
      }
      private static string GetValue(string line, ref int position)
      {
        string value;
        char? prefix;
        string endWith;
        switch (line[position])
        {
        case '\'':
        case '\"':
          prefix = line[position];
          endWith = prefix + ",";
          position++;
          break;
        default:
          prefix = null;
          endWith = ",";
          break;
        }
        var endPosition = line.IndexOf(endWith, position);
        if (endPosition < 0 && prefix.HasValue)
        {
          if (line[line.Length - 1] == prefix.Value)
          {
            value = line.Substring(position, line.Length - 1 - position);
            position = line.Length;
            return Fixprefix(value, prefix.Value.ToString());
          }
          position--;
          endPosition = line.IndexOf(',', position);
        }
        if (endPosition < 0)
        {
          value = line.Substring(position);
          position = line.Length;
          return value;
        }
        if (prefix.HasValue)
        {
          value = line.Substring(position, endPosition - position);
          position = endPosition + endWith.Length;
          return Fixprefix(value, prefix.Value.ToString());
        }
        value = line.Substring(position, endPosition - position);
        position = endPosition + endWith.Length;
        return value;
      }
      private static string Fixprefix(string value, string prefix) => value.Replace(prefix + prefix, prefix);
    }
