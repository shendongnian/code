    using (FileStream fs = new FileStream("File.txt", FileMode.Open, FileAccess.Read))
    {
        using (StreamReader sr = new StreamReader(fs))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                var match = Regex.Match(line, @"WORK.Test has (\d+) observations and (\d+) variables");
                if (match.Success)
                {
                    int.TryParse(match.Groups[1].Value, out int observations);
                    int.TryParse(match.Groups[2].Value, out int variables);
                    // Send EMail etc.
                }
            }
        }
    }
