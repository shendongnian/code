        string inputFilename = "input.txt";
        string outputFilename = "output.txt";
        using (StreamWriter streamWriter = File.AppendText(outputFilename))
        {
            string[] contents = File.ReadAllLines(inputFilename);
            foreach (string content in contents)
            {
                string[] splitlines = content.Split('|');
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
