    string[] contents = File.ReadAllLines(filename);
    foreach (string line in contents)
    {
        string[] splitlines = Regex.Split(line);
        foreach (string splitline in splitlines)
        {
            string prefix = Regex.Match(splitline, @"(\S+)(\d+)").Groups[0].Value;
            File.AppendAllText(workingdirform2 + "configuration.txt", prefix+"\r\n");
        }
    }
