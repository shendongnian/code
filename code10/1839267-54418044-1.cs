      string fileContent = File.ReadAllText(@"path to txt file");
      Match match = Regex.Match(fileContent, @"Script Start Date: (.+)\nScript Start Time: (.+)");
      if (match.Success)
      {
        // Here I use Substring method, to cut out "Fri", as it's not necessary to parse to DateTime
        DateTime.TryParse(match.Groups[1].Value.Substring(4) + " " + match.Groups[2], out DateTime dt);
        Console.WriteLine(dt);
        Console.ReadKey();
      }
    
