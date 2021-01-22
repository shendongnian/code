    string input = File.ReadAllText(inputFilePath);
    MatchCollection lines = Regex.Matches(input, ".{1200}"); // matches any character 1200 times
    StringBuilder output = new StringBuilder();
    
    foreach (Match line in lines)
    {
        output.AppendLine(line.Value);
    }
    
    File.AppendAllText(outputFilePath, output.ToString());
