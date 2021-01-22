    string input = File.ReadAllText(inputFilePath);
    Match match = Regex.Match(input, "(.{1200})"); // matches any character 1200 times and groups it
    StringBuilder output = new StringBuilder();
    
    foreach (Group line in match.Groups)
    {
        output.AppendLine(line.Value);
    }
    
    File.AppendAllText(outputFilePath, output.ToString());
