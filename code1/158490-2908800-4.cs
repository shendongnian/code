    string input = File.ReadAllText(inputFilePath);
    MatchCollection lines = Regex.Matches(input, ".{1200}", RegexOptions.Singleline); // matches any character including \n exactly 1200 times
    StringBuilder output = new StringBuilder();
    
    foreach (Match line in lines)
    {
        output.AppendLine(line.Value);
    }
    
    File.AppendAllText(outputFilePath, output.ToString());
