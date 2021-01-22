    private static readonly Regex LocationPattern = new Regex(@"^(\d+), (\d+)$");
    ...
    using (TextReader reader = File.OpenText(filename))
    {
        while (true)
        {
            string control = reader.ReadLine();
            string text = reader.ReadLine();
            string location = reader.ReadLine();
            if (control == null)
            {
                break;
            }
            if (text == null || location == null)
            {
                // Or however you want to handle this...
                throw new InvalidConfigurationFileException
                    ("Incorrect number of lines");
            }
            if (text.Length < 2 || !text.StartsWith("\"") || !text.EndsWith("\""))
            {
                // Or however you want to handle this...
                throw new InvalidConfigurationFileException
                    ("Text is not in quotes");
            }
            text = text.Substring(1, text.Length - 2);
            Match locationMatch = LocationPattern.Match(location);
            if (!locationMatch.Success)
            {
                // Or however you want to handle this...
                throw new InvalidConfigurationFileException
                    ("Invalid location: " + location);
            }
            // You could use int.TryParse if you want to handle this differently
            Point parsedLocation = new Point(int.Parse(match.Groups[1].Value),
                                             int.Parse(match.Groups[2].Value));
            // Now the rest of the code before
        }
    }
