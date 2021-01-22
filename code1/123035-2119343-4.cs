    string inputFilename = "input.txt";
    string outputFilename = "output.txt";
    using (StreamWriter streamWriter = File.AppendText(outputFilename))
    {
        using (StreamReader streamReader = File.OpenText(inputFilename))
        {
            while (true)
            {
                string line = streamReader.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] splitlines = line.Split('|');
                foreach (string split in splitlines)
                {
                    Match match = Regex.Match(split, @"\S+\d+");
                    if (match.Success)
                    {
                        string prefix = match.Groups[0].Value;
                        streamWriter.WriteLine(prefix);
                    }
                    else
                    {
                        // Handle match failed...
                    }
                }
            }
        }
    }
