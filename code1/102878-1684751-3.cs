    string[] tests = new string[] {
      "paul vs Team Apple Orange",
      "Team Apple Orange vs paul",
      "Team Apple Orange v.s. paul"
    };
    
    foreach (string line in tests)
    {
      string pattern = "(?:Team )?(.*?)\\s+(?:vs|v\\.s\\.)\\s+(?:Team )?(.*)";
      Regex regex = new Regex(pattern);
      Match match = regex.Match(line);
      Console.WriteLine(line);
      if (match.Success)
      {
        string team1 = match.Groups[1].Value;
        string team2 = match.Groups[2].Value;
        Console.WriteLine("Team 1 : " + team1);
        Console.WriteLine("Team 2 : " + team2);
      }
      else
      {
        Console.WriteLine("No match found");
      }
      Console.WriteLine();
    }
    Console.ReadLine();
